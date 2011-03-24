// 
// Main.cs
//  
// Author:
//       Mario Alberto Chavez <mario.chavez@gmail.com>
// 
// Copyright (c) 2011 Mario Alberto Chavez
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

namespace Cesun.Thread.Delegates
{

	public delegate void PrintDataWithDelegate();
	
	class MainClass
	{
		public static void Main (string[] args)
		{
			Cesun.MultiHilos.Hilos hilos = new Cesun.MultiHilos.Hilos ();
			hilos.Start ();
			return;
			
			Console.WriteLine ("Iniciando tarea");
			
			var mainClass = new MainClass ();
			var data = new Message ();
			
			PrintDataWithDelegate printDataDeletgate = 
				mainClass.PrintData;
			IAsyncResult result = printDataDeletgate.BeginInvoke 
 (mainClass.Callback, data);
			
			Console.WriteLine ("Finalizando tarea");
			
			do {
				Console.WriteLine ("Aun no termina!");
				System.Threading.Thread.Sleep (500);
			} while (!result.IsCompleted);
			
			Console.ReadLine ();
		}
		
		public void Callback (IAsyncResult asyncResult)
		{
			//asyncResult.AsyncState = "Hola desde el hilo";
			Console.WriteLine ("Callback");
		}
		
		public void PrintData ()
		{
			for (int i = 0; i < 20; i++) {
				Console.WriteLine ("Ejecutando print data");
				System.Threading.Thread.Sleep (1000);
			}
		}
	}
	
	public class Message
	{
		public string Info { get; set; }
	}
}
