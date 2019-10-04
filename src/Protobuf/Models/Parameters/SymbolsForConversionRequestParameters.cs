﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class SymbolsForConversionRequestParameters : ParametersBase
    {
        public SymbolsForConversionRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_FOR_CONVERSION_REQ)
        {
        }

        public long AccountId { get; set; }

        public long FirstAssetId { get; set; }

        public long LastAssetId { get; set; }
    }
}