using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
	public interface ILoggerWithIP<T> : ILogEventEnricher
	{
		ILogger Logger { get; }
	}
}