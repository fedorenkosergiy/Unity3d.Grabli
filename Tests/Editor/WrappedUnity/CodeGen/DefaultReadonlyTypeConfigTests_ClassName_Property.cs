﻿using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultReadonlyTypeConfigTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckClassNameIfThrowsWhenNotInitialized(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Factory factory = CreateFakeFactory();
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                string unused = config.ClassName;
            });
        }
        
        [TestCase(RootTypeGuidApplication, "DefaultApplication")]
        [TestCase(RootTypeGuidScreen, "DefaultScreen")]
        public void CheckClassNameIfWorks(string guid, string expected)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
                string actual = config.ClassName;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}