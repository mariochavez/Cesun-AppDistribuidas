// 
// Utilities.asmx.cs
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
using System.Web;
using System.Web.Services;

namespace SampleWSApp.Server
{
	[WebService(Namespace = "http://www.cesun.edu")]
	public class Utilities : System.Web.Services.WebService
	{
		[WebMethod]
		public decimal ShipmentCost (int destination)
		{
			var cacheValue = Context.Cache [destination.ToString ()];
			if (cacheValue != null)
				return Decimal.Parse(cacheValue.ToString());
			
			if (destination < 10) {
				Console.WriteLine ("Menor");
				Context.Cache [destination.ToString ()] = 5.5m;
				return 5.5m;
			} else {
				Console.WriteLine ("Mayor");
				Context.Cache [destination.ToString ()] = 10.5m;
				return 10.5m;
			}
		}
		
		[WebMethod(CacheDuration = 10)]
		public
			string[] Cities ()
		{
			string[] cities = new string[4];
			cities [0] = "Tijuana";
			cities [1] = "Mexicali";
			cities [2] = "Ensenada";
			cities [3] = DateTime.Now.ToString ();
			
			return cities;
		}
	}
}

