require 'json'
require 'pp'
require 'test/unit'
require './passkit.rb'

$VERBOSE = true

class TestiOS7 < Test::Unit::TestCase
  def setup
    h = JSON.parse IO.read "#{ENV['HOME']}/.passkit.json"
    @pk = PassKit.new(h['key'], h['secret'])
    @data = {
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
    @j = JSON.parse @pk.pass_update_passid('feKpNoscFpL9', @data)
    assert @j['success']
    @j = JSON.parse @pk.pass_get_passid('feKpNoscFpL9')
    assert @j['success']
  end
  def test_expirationDate
    k = 'expirationDate'
    assert_equal(@data[k], @j[k])
  end
  def test_voided
    k = 'voided'
    assert_equal(@data[k], @j[k])
  end
  def test_groupingIdentifier
    k = 'groupingIdentifier'
    assert_equal(@data[k], @j[k])
  end
  def test_ignoresTimeZone
    k = 'ignoresTimeZone'
    assert_equal(@data[k], @j[k])
  end
  def test_associatedStoreIdentifiers
    k = 'associatedStoreIdentifiers'
    assert_equal(@data[k], @j[k])
  end
  def test_appLaunchURL
    k = 'appLaunchURL'
    assert_equal(@data[k], @j[k])
  end
  def test_userInfo
    k = 'userInfo'
    assert_equal(@data[k], @j[k])
  end
  def test_beacons
    k = 'beacons'
    assert_equal(@data[k], @j[k])
  end
end
