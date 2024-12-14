using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : LogicComponent
{

	public LogicComponent input;

	public void Update()
	{
		output = input.output;
	}

}
