using System;

using NLua;

class NLuaRepro
{
	public static void Main(string[] args)
	{
		new NLuaRepro().Repro();
	}

	public void Repro()
    {
		using var lua = new Lua();
		lua.RegisterFunction("print", this, typeof(NLuaRepro).GetMethod(nameof(Print)));
		lua.LoadString(@"
			local t = {}
			t[0] = 1
			t[1] = 0
			print(t)",
			"repro"
		).Call();
	}

	public static void Print(params object[] outputs)
	{
		Console.WriteLine($"outputs[0] {(outputs[0] is LuaTable ? "is" : "is not")} LuaTable");
	}
}