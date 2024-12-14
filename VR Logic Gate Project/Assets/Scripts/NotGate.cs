using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : LogicComponent
{

	public LogicComponent input;

	public void Update()
	{
		output = !input.output;
	}

}
