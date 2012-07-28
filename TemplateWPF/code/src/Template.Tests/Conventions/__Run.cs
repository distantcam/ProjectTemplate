using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ApprovalTests.Reporters;
using Xunit.Extensions;

[assembly: FrontLoadedReporter(typeof(NCrunchReporter))]
[assembly: UseReporter(typeof(DiffReporter))]

namespace ConventionTests
{
    public class ConventionTestsRunner
    {
        public static IEnumerable<object[]> Conventions
        {
            get
            {
                return GetConventionTypes().Select(t => new object[] { BuildTestData(t) }).ToArray();
            }
        }

        private static TestCaseData BuildTestData(Type t)
        {
            var convention = CreateConvention(t);
            return new TestCaseData(convention.Name, convention);
        }

        private static IConventionTest CreateConvention(Type t)
        {
            return (IConventionTest)Activator.CreateInstance(t);
        }

        private static Type[] GetConventionTypes()
        {
            var types = Assembly.GetExecutingAssembly()
                .GetExportedTypes()
                .Where(IsConventionTest)
                .ToArray();
            return types;
        }

        private static bool IsConventionTest(Type type)
        {
            return type.IsClass && type.IsConcrete<IConventionTest>();
        }

        [ConventionTest]
        [PropertyData("Conventions")]
        public void Run(IConventionTest test)
        {
            test.Execute();
        }
    }
}