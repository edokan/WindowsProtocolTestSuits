// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Protocols.TestTools.StackSdk.Asn1;

namespace Microsoft.Protocols.TestTools.StackSdk.ActiveDirectory.Adts.Asn1CodecV2
{
    /*
    AddRequest_attrs_element ::= SEQUENCE {
                             type          AttributeType,
                             values        SET OF AttributeValue
                        }

    */
    public class AddRequest_attrs_element : Asn1Sequence
    {
        [Asn1Field(0)]
        public AttributeType type { get; set; }
        
        [Asn1Field(1)]
        public Asn1SetOf<AttributeValue> values { get; set; }
        
        public AddRequest_attrs_element()
        {
            this.type = null;
            this.values = null;
        }
        
        public AddRequest_attrs_element(
         AttributeType type,
         Asn1SetOf<AttributeValue> values)
        {
            this.type = type;
            this.values = values;
        }
    }
}

