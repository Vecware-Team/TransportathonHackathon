﻿using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetByKey
{
    public class GetByKeyTranslateResponse
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Language Language { get; set; }
    }
}
