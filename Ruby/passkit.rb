require 'json'
require 'uri'
require 'net/http'
require 'net/http/digest_auth'

require './config.rb'

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
    h.use_ssl = uri.scheme == 'https'
  
    req = Net::HTTP::Get.new uri.request_uri
  
    res = h.request req
  
    digest_auth = Net::HTTP::DigestAuth.new
    auth = digest_auth.auth_header uri, res['www-authenticate'], 'GET'
  
    req = Net::HTTP::Get.new uri.request_uri
    req.add_field 'Authorization', auth
  
    res = h.request req
  
    res.body
  end

  def authenticate
    get('authenticate')
  end
  def template_list
    get('template/list')
  end
end
