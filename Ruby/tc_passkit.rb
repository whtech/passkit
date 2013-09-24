require 'json'
require 'pp'
require 'test/unit'
require './passkit.rb'

$VERBOSE = true

class TestPassKit < Test::Unit::TestCase
  def setup
    h = JSON.parse IO.read "#{ENV['HOME']}/.passkit.json"
    @pk = PassKit.new(h['key'], h['secret'])
  end
  def test_authenticate
    h = JSON.parse @pk.authenticate
    assert h['success']
    assert h.has_key?('username')
  end
  def test_template_list
    h = JSON.parse @pk.template_list
    assert h['success']
    assert h.has_key?('templates')
  end
  def test_template_fieldnames
    templates = JSON.parse @pk.template_list
    templates['templates'].each do |t|
      h = JSON.parse @pk.template_fieldnames t
      assert h['success']
    end
  end
  def test_template_passes
    templates = JSON.parse @pk.template_list
    templates['templates'].each do |t|
      h = JSON.parse @pk.template_passes t
      assert h['success']
    end
  end
  def test_template_update
    j = JSON.parse @pk.template_update('test', {'textItem' => 'New Defaults'})
    assert j['success']
  end
  def test_pass_update_passid
    data = {
      'expirationDate' => '2013-09-17T06:44Z',
      'voided' => true,
      'groupingIdentifier' => 'PassKit',
      'ignoresTimeZone' => true,
      'associatedStoreIdentifiers' => 12345678,
      'appLaunchURL' => 'http://passkit.com',
      'userInfo' => '{"name": "Percy PassKit"}',
      'beacons' => [{
	'major' => 123456,
	'minor' => 654321,
	'proximityUUID' => 'I AM A UNIQUE ID',
	'relevantText' => 'irrelevant'
      }]
    }
    j = JSON.parse @pk.pass_update_passid('feKpNoscFpL9', data)
    assert j['success']
  end
end
