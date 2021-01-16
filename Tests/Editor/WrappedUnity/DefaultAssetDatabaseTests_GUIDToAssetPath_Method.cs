﻿using System;
using NUnit.Framework;

namespace Grabli.WrappedUnity
{
	public partial class DefaultAssetDatabaseTests
	{
		[Test]
		public void CheckGUIDToAssetPathDoesNotThrow()
		{
			var assetDatabase = new DefaultAssetDatabase();
			Assert.DoesNotThrow(() =>
			{
				string guid = Guid.NewGuid().ToString("N");
				assetDatabase.GUIDToAssetPath(guid);
			});
		}
	}
}
