require 'json'
require 'uri'
require 'net/http'
require 'net/http/digest_auth'

require './config.rb'

class PassKit
  def initialize(key, secret)
    @key	= key
    @secret	= secret
  end
end

def authenticate
  uri = URI.parse 'https://api.passkit.com/v1/authenticate'
  uri.user = $key
  uri.password = $secret

  h = Net::HTTP.new uri.host, uri.port
  h.use_ssl = uri.scheme == 'https'

  req = Net::HTTP::Get.new uri.request_uri

  res = h.request req

  digest_auth = Net::HTTP::DigestAuth.new
  auth = digest_auth.auth_header uri, res['www-authenticate'], 'GET'

  req = Net::HTTP::Get.new uri.request_uri
  req.add_field 'Authorization', auth

  res = h.request req

  puts res.body
end

def template_list
  uri = URI.parse 'https://api.passkit.com/v1/template/list'
  uri.user = $key
  uri.password = $secret

  h = Net::HTTP.new uri.host, uri.port
  h.use_ssl = uri.scheme == 'https'

  req = Net::HTTP::Get.new uri.request_uri

  res = h.request req

  digest_auth = Net::HTTP::DigestAuth.new
  auth = digest_auth.auth_header uri, res['www-authenticate'], 'GET'

  req = Net::HTTP::Get.new uri.request_uri
  req.add_field 'Authorization', auth

  res = h.request req

  puts res.body
end

authenticate
template_list
