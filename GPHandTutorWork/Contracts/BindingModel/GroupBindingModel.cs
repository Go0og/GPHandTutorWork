﻿using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.BindingModel
{
	public class GroupBindingModel : IGroup
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public int TutorID { get; set; }
	}
}