﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SearchModel
{
	public class GroupSearchModel
	{
		public int? Id { get; set; }
		public string? Name { get; set; }

		public int? TutorID { get; set; }
	}
}
