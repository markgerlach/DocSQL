using System;
using System.Reflection;
using System.Text;
using System.IO;
using System.Data;

namespace DocSQL_2017
{
	public class DocSQL_2017Exception : Exception
	{
		public DocSQL_2017Exception()
		{
		}

		public DocSQL_2017Exception(string message)
			: base(message)
		{
		}
	}
}
