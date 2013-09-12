require 'net/http'
require 'net/http/digest_auth'
require 'net/https'
require 'uri'

class PassKit
  API_URL = 'https://api.passkit.com/v1/'

  def initialize(key, secret)
    @key	= key
    @secret	= secret
  end

  def get(path)
    uri = URI.parse API_URL + path
    uri.user = @key
    uri.password = @secret
  
    h = Net::HTTP.new uri.host, uri.port
    if (uri.scheme == 'https')
      h.use_ssl = true
      #h.ca_path = '/etc/ssl/cert.pem'
      #h.verify_mode = OpenSSL::SSL::VERIFY_PEER
      #h.verify_depth = 5
    end
  
    req = Net::HTTP::Get.new uri.request_uri
    res = h.request req
    if (res.code == '401')
      digest_auth = Net::HTTP::DigestAuth.new
      if (res['www-authenticate'] == nil)
	warn "warning: missing www-authenticate header"
        return res.body
      end
      auth = digest_auth.auth_header uri, res['www-authenticate'], 'GET'

      req.add_field 'Authorization', auth
      res = h.request req
    else
      warn "warning: expected 401 Unauthorized header, got " + res.code
    end

    res.body
  end

  def authenticate
    get('authenticate')
  end
  def template_list
    get('template/list')
  end
  def template_fieldnames(template)
    get("template/#{URI.escape template}/fieldnames")
  end
  def template_passes(template)
    get("template/#{URI.escape template}/passes")
  end
  def template_update(template, data)
    enc_data = []
    data.each do |k, v|
      enc_data.push(URI.escape(k) + '=' + URI.escape(v))
    end
    enc_str = enc_data.join '&'
    get("template/update/#{URI.escape template}/?#{enc_str}")
  end
end
