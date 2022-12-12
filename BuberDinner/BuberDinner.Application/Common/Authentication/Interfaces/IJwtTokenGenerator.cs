﻿using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Authentication.Interfaces
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(User user);
	}
}
