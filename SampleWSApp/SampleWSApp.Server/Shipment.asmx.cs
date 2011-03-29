// 
// Shipment.asmx.cs
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
using System.Web.Services.Protocols;
using SampleWSApp.Server.Services;

namespace SampleWSApp.Server
{
	[WebService(Namespace = "http://www.cesun.edu")]
	public class Shipment : System.Web.Services.WebService
	{
		public SecurityHeader securityHeader;
		
		[WebMethod]
		[SoapHeader("securityHeader")]
		public bool Send (string to, string from)
		{
			//WindowsIndetity.GetCurrent.Name # Dentro del domino
			
			//User.Identity.Name # Control con usuarios del IIS
			
			if (!AuthenticationService.Verify (securityHeader.Token))
				throw new ApplicationException ("Usuario desconocido");
			
			Console.WriteLine ("Shipment received");
			return true;
		}
	}
}
