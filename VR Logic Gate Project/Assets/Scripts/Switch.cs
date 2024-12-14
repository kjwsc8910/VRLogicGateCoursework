using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : LogicComponent
{

	public void Toggle()
	{
		output = !output;
	}

}
