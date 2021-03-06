﻿using Natasha;
using System;
using System.IO;
using Xunit;

namespace NatashaUT
{

    [Trait("程序集编译测试", "文件")]
    public class AssemblyFileTest
    {
        [Fact(DisplayName = "文件部分类编译")]
        public void Test1()
        {

            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File",  "TextFile1.txt");
            string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File", "TestFileModel.cs");
            
            
            NAssembly assembly = new NAssembly();
            assembly.AddFile(path1);
            assembly.AddFile(path2);


            var result = assembly.Compile();
            Assert.NotNull(result);


            var type = assembly.GetType("aaa.TestFileModel");
            Assert.NotNull(type);
            Assert.Equal("TestFileModel", type.Name);


            var @delegate = NDelegate.Random().Func<string>("return new TestFileModel().Name;", result);
            Assert.Equal("aaa",@delegate());
        }
    }
}
