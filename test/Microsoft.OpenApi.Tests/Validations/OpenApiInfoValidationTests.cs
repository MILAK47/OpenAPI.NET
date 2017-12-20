﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. 

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Properties;
using Xunit;

namespace Microsoft.OpenApi.Validations.Tests
{
    public class OpenApiInfoValidationTests
    {
        [Fact]
        public void ValidateFieldIsRequiredInInfo()
        {
            // Arrange
            string urlError = String.Format(SRResource.Validation_FieldIsRequired, "url", "info");
            string versionError = String.Format(SRResource.Validation_FieldIsRequired, "version", "info");
            IEnumerable<ValidationError> errors;
            OpenApiInfo info = new OpenApiInfo();

            // Act
            bool result = info.Validate(out errors);

            // Assert
            Assert.False(result);
            Assert.NotNull(errors);

            Assert.Equal(new[] { urlError, versionError }, errors.Select(e => e.ErrorMessage));
        }
    }
}
