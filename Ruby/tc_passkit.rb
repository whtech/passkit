require './passkit.rb'
require 'json'
require 'test/unit'

require './config.rb'

class TestPassKit < Test::Unit::TestCase
  def setup
    @pk = PassKit.new($key, $secret)
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
