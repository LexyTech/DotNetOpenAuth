﻿//-----------------------------------------------------------------------
// <copyright file="AssociateUnsuccessfulResponseTests.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOpenAuth.Test.OpenId.Messages {
	using DotNetOpenAuth.Messaging;
	using DotNetOpenAuth.OpenId;
	using DotNetOpenAuth.OpenId.Messages;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class AssociateUnsuccessfulResponseTests {
		private AssociateUnsuccessfulResponse response;

		[TestInitialize]
		public void Setup() {
			this.response = new AssociateUnsuccessfulResponse();
		}

		[TestMethod]
		public void ParameterNames() {
			this.response.ErrorMessage = "Some Error";
			this.response.AssociationType = "HMAC-SHA1";
			this.response.SessionType = "DH-SHA1";

			MessageSerializer serializer = MessageSerializer.Get(this.response.GetType());
			var fields = serializer.Serialize(this.response);
			Assert.AreEqual(Protocol.OpenId2Namespace, fields["ns"]);
			Assert.AreEqual("unsupported-type", fields["error_code"]);
			Assert.AreEqual("Some Error", fields["error"]);
			Assert.AreEqual("HMAC-SHA1", fields["assoc_type"]);
			Assert.AreEqual("DH-SHA1", fields["session_type"]);
		}
	}
}