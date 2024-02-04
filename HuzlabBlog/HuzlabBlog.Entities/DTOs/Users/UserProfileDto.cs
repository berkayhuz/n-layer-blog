﻿using HuzlabBlog.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace HuzlabBlog.Entities.DTOs.Users
{
	public class UserProfileDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
        public string Biography { get; set; }
        public string CurrentPassword { get; set; }
		public string? NewPassword { get; set; }
		public IFormFile? Photo { get; set; } 
		public Image Image { get; set; }
    }
}
