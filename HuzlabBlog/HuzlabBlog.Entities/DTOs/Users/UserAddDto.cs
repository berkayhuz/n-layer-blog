﻿using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Entities.DTOs.Users
{
    public class UserAddDto
    {
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public string Email {  get; set; }
        public string Biography {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Password {  get; set; }
        public Guid RoleId {  get; set; }
        public List<AppRole> Roles {  get; set; }
    }
}