using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
		public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
            var r = (byte)'\x1';
            vm.RegisterCommand('.', b => write(System.Text.Encoding.ASCII.GetString(vm.Memory, vm.MemoryPointer, 1)[0]));
            vm.RegisterCommand('+', b =>
            {
                if (vm.Memory[vm.MemoryPointer]<255) vm.Memory[vm.MemoryPointer]++;
                else vm.Memory[vm.MemoryPointer] = 0;

            });
            vm.RegisterCommand('-', b =>
            {
                if (vm.Memory[vm.MemoryPointer] > 0) vm.Memory[vm.MemoryPointer]--;
                else vm.Memory[vm.MemoryPointer] = 255;

            });
            vm.RegisterCommand(',', b => vm.Memory[vm.MemoryPointer]=(byte)read());
            vm.RegisterCommand('>', b => 
            {
                if (vm.MemoryPointer < vm.Memory.Length - 1) vm.MemoryPointer++;
                else vm.MemoryPointer=0;
                    
            });
            vm.RegisterCommand('<', b =>
            {
                if (vm.MemoryPointer> 0) vm.MemoryPointer--;
                else vm.MemoryPointer = vm.Memory.Length-1;

            });
            for (char i='a';i<='z';i++)
			{
				var c =i;
                var l = (byte)i;
                vm.RegisterCommand(c, b => vm.Memory[vm.MemoryPointer]= l);
            }

            for (char i = 'A'; i <= 'Z'; i++)
            {
                var c = i;
                var l = (byte)i;
                vm.RegisterCommand(c, b => vm.Memory[vm.MemoryPointer] = l);
            }

            for (int i = 0;i<10;i++)
            {
                var c = (char)i;
                var l = (byte)i;
                vm.RegisterCommand(c, b => vm.Memory[vm.MemoryPointer] = l);
            }
        }
	}
}