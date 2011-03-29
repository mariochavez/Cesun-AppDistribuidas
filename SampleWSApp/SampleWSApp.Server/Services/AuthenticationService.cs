// 
// AuthenticationService.cs
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

namespace SampleWSApp.Server.Services
{
	public class AuthenticationService
	{
		public static string userToken;
		public static DateTime timestamp;
		public static string ipAddress;
		
		public AuthenticationService ()
		{
		}
		
		public static string Authenticate (string username, string passwordHash)
		{
			if (username != "usuario_secreto" & passwordHash != "password_secreto")
				throw new ApplicationException ("Usuario invalido");
			
			userToken = Guid.NewGuid ().ToString();
			timestamp = DateTime.Now.AddMinutes(2);
			ipAddress = "127.0.0.1"; 
			
			return userToken;
		}
		
		public static bool Verify (string token)
		{
			if (token != userToken | DateTime.Now > timestamp)
				return false;
			
			return true;
		}
	}
}

