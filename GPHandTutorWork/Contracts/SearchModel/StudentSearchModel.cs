﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SearchModel
{
	public class StudentSearchModel
	{
		public int? Id { get; set; }
		public string? FIO { get; set; }

		public int? GroupID { get; set; }
	}
}