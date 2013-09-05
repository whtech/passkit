require './passkit.rb'
require 'test/unit'

class TestPassKit < Test::Unit::TestCase
  def test_passkit
    pk = PassKit.new($key, $secret)
    pk.authenticate
    pk.template_list
  end
end
