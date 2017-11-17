using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace DocSQL_2017
{
	public interface IDocSQL_2017HelpAccessible
	{
		string HelpCode { get; set; }
		void ShowHelp();
		void ShowHelp(string helpCode);
	}

	public interface IDocSQL_2017DisposeObjects
	{
		void DisposeObjects();
	}
}
