require 'json'
require 'test/unit'
require './passkit.rb'

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
end
