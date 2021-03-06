﻿using System;
using Mantle.Aws;

namespace Mantle.Messaging.Aws
{
    public class SqsPublisherEndpoint : SqsEndpoint, IPublisherEndpoint
    {
        private readonly IAwsConfiguration awsConfiguration;

        public SqsPublisherEndpoint(IAwsConfiguration awsConfiguration)
        {
            if (awsConfiguration == null)
                throw new ArgumentNullException("awsConfiguration");

            awsConfiguration.Validate();

            this.awsConfiguration = awsConfiguration;
        }

        public IPublisherClient GetClient()
        {
            return new SqsPublisherClient(this, awsConfiguration);
        }

        public IPublisherEndpointManager GetManager()
        {
            return new SqsPublisherEndpointManager(this, awsConfiguration);
        }
    }
}