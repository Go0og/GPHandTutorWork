﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
	public interface ITutorModel : Iid
	{
		string FIO { get; }
		string Login { get; }
		string Password { get; }
	}
}