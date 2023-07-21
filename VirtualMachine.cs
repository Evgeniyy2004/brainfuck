using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }
		Dictionary<char,Action<IVirtualMachine>> all =new Dictionary<char, Action<IVirtualMachine>>();

		public VirtualMachine(string program, int memorySize)
		{
			Memory=new byte[memorySize];
			Instructions=program;
			InstructionPointer = 0;
			MemoryPointer = 0;
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
			if(!all.ContainsKey(symbol)) all.Add(symbol, execute);
		}

		public void Run()
		{
			while (InstructionPointer < Instructions.Length)
			{
                if (all.ContainsKey((char)Instructions[InstructionPointer]))
				{
					all[Instructions[InstructionPointer]](this);
				}

				else
				{

				}
                InstructionPointer++;
            }
		}
	}
}