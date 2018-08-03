using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class ScriptManager : MonoBehaviour {

	public void Start () {
		// print(MoonSharpFactorial());
		MoonSharpFactorial();
	}
	
	void MoonSharpFactorial() {
		string script = @"    
			-- defines a factorial function
			function fact (n)
				if (n == 0) then
					return 1
				else
					return n*fact(n - 1)
				end
			end

			squares = {1, 4, 9, 16, 25, 36, 49, 64, 81}
			return squares";

		DynValue res = Script.RunString(script);
		print(res.Callback);
		// return res.Number;
	}

}
