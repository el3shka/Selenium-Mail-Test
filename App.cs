using System;
using System.Threading;
using System.Configuration;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;


namespace RamblerTest
{
	class App
	{
		private TimeSpan expectationTime = TimeSpan.FromSeconds(10);
		private TimeSpan sleepTime = TimeSpan.FromSeconds(10);

		public void Sleep()
		{
			Thread.Sleep(this.sleepTime);
		}
		public TimeSpan SetGetExpectationTimeTime(double value)
		{
			this.sleepTime = TimeSpan.FromSeconds(value);
			return this.sleepTime;
		}
		public TimeSpan GetExpectationTime()
		{
			return this.expectationTime;
		}
		/*public TimeSpan SetExpectationTime(double value);
	{
	    this.expectationTime = TimeSpan.FromSeconds(value);
		return this.expectationTime;
     } */
	}
}
