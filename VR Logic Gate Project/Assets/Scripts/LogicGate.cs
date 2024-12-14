using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogicGate : LogicComponent
{

	public enum Operator
	{
		AND,
		OR,
		XOR
	}

	public LogicComponent inputA, inputB;
	public Operator op;
	public bool not;

	public void Update()
	{
		switch(op)
		{
			case Operator.AND:
				output = inputA.output && inputB.output;
				output = output ^ not;
				break;
			case Operator.OR:
				output = inputA.output || inputB.output;
				output = output ^ not;
				break;
			case Operator.XOR:
				output = inputA.output ^ inputB.output;
				output = output ^ not;
				break;
		}
	}

}
