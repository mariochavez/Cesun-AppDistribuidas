// 
// Hilos.cs
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
using System.Threading;

namespace Cesun.MultiHilos
{
	public class Hilos
	{
		public int Count { get; set; }
		
		public Hilos ()
		{
		}
		
		public void Start ()
		{
			System.Threading.Thread work1 = new System.Threading.Thread (WorkA);
			System.Threading.Thread work2 = new System.Threading.Thread (WorkB);
			
			work1.Priority = ThreadPriority.Lowest;
			work2.Priority = ThreadPriority.Highest;
			
			work1.Start();
			work2.Start();
			
			work1.Suspend();
			Console.ReadLine();
			work1.Resume();
			
			Console.ReadLine();
	}
		
		public void WorkA ()
		{
			int max = 20;
			for (int i = 0; i < max; i++) {
				Console.WriteLine (String.Format ("Thread A: {0}", i));	
				System.Threading.Thread.Sleep (1000);
				
				IncrementCount();
			}
		}
		
		public void WorkB ()
		{
			int max = 20;
			for (int i = 0; i < max; i++) {
				Console.WriteLine (String.Format ("Thread B: {0}", i));	
				System.Threading.Thread.Sleep (2000);
				
				IncrementCount();
			}
		}
		
		public void IncrementCount ()
		{
			lock("mylock") {
				int newCount = Count;
				System.Threading.Thread.Sleep (100);
				Count = (newCount + 1);
				Console.WriteLine (String.Format ("Counter: {0}", Count));
			}
		}
	}
}

