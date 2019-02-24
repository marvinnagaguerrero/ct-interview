using AutoMapper;
using Ct.Interview.Web.Api.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ct_interview_tests
{
    public static class App
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            Mapper.Configuration.AssertConfigurationIsValid();

        }
    }
}
