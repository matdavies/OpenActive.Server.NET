﻿using OpenActive.DatasetSite.NET;
using OpenActive.NET;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenActive.Server.NET
{
    public class ModelSupport<TComponents> where TComponents : class, IBookableIdComponents, new()
    {
        public Uri JsonLdIdBaseUrl { get; private set; }
        private BookablePairIdTemplate<TComponents> IdTemplate { get; set; }

        protected internal void SetConfiguration(BookingEngineSettings settings, BookablePairIdTemplate<TComponents> template)
        {
            this.IdTemplate = template;

            this.JsonLdIdBaseUrl = settings.JsonLdIdBaseUrl;
        }

        /// <summary>
        /// Use OpportunityType from components
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        protected Uri RenderOpportunityId(TComponents components)
        {
            return IdTemplate.RenderOpportunityId(components);
        }
        /// <summary>
        /// Use OpportunityType from components
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        protected Uri RenderOfferId(TComponents components)
        {
            return IdTemplate.RenderOfferId(components);
        }
        protected Uri RenderOpportunityId(OpportunityType opportunityType, TComponents components)
        {
            return IdTemplate.RenderOpportunityId(opportunityType, components);
        }

        protected Uri RenderOfferId(OpportunityType opportunityType, TComponents components)
        {
            return IdTemplate.RenderOfferId(opportunityType, components);
        }
    }
}
