// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Protocols.TestTools.StackSdk.Asn1;
using Microsoft.Protocols.TestTools.StackSdk.Security.KerberosLib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Microsoft.Protocols.TestTools.StackSdk.Security.Kile
{
    /// <summary>
    /// Maintain the important parameters during KILE transport.
    /// </summary>
    public class KileServerContext : KileContext
    {
        #region Private Members

        /// <summary>
        /// The realm of server. Get from AS request or TGS request.
        /// </summary>
        private PrincipalName sName;

        /// <summary>
        /// Encryption key used to encrypt ticket in AsResponse.
        /// </summary>
        private EncryptionKey ticketEncryptKey;

        /// <summary>
        /// User desired encryption type. Get from AS request.
        /// </summary>
        private Asn1SequenceOf<KerbInt32> encryptType;

        /// <summary>
        /// Specifies the addresses from which the requested ticket is to be valid. Get from AS request.
        /// </summary>
        private HostAddresses addresses;

        /// <summary>
        /// Hold a random number generated by the client
        /// </summary>
        private KerbUInt32 nonce;

        /// <summary>
        /// The sub-session key in authenticator from TGS Request
        /// </summary>
        private EncryptionKey tgsSubSessionKey;

        /// <summary>
        /// The ticket returned from TGS request.
        /// </summary>
        private EncTicketPart tgsTicket;

        /// <summary>
        /// Requested end time of ticket. Get from AS request.
        /// </summary>
        internal KerberosTime endTime;

        /// <summary>
        /// Requested renew-till time of the ticket. Get from AS request.
        /// </summary>
        internal KerberosTime rtime;

        #endregion


        #region Properties

        /// <summary>
        /// The realm of server. Get from AS request or TGS request.
        /// </summary>
        [CLSCompliant(false)]
        public PrincipalName SName
        {
            get
            {
                return sName;
            }
            set
            {
                sName = value;
            }
        }


        /// <summary>
        /// Specifies the addresses from which the requested ticket is to be valid. Get from AS request.
        /// </summary>
        [CLSCompliant(false)]
        public HostAddresses Addresses
        {
            get
            {
                return addresses;
            }
            set
            {
                addresses = value;
            }
        }


        /// <summary>
        /// Encryption key used to encrypt ticket in AsResponse.
        /// </summary>
        [CLSCompliant(false)]
        public EncryptionKey TicketEncryptKey
        {
            get
            {
                return ticketEncryptKey;
            }
            set
            {
                ticketEncryptKey = value;
            }
        }

        /// <summary>
        /// User desired encryption type. Get from AS request.
        /// </summary>
        [CLSCompliant(false)]
        public Asn1SequenceOf<KerbInt32> EncryptType
        {
            get
            {
                return encryptType;
            }
            set
            {
                encryptType = value;
            }
        }


        /// <summary>
        /// Hold a random number generated by the client
        /// </summary>
        [CLSCompliant(false)]
        public KerbUInt32 Nonce
        {
            get
            {
                return nonce;
            }
            set
            {
                nonce = value;
            }
        }


        /// <summary>
        /// The sub-session key in authenticator from TGS Request
        /// </summary>
        [CLSCompliant(false)]
        public EncryptionKey TgsSubSessionKey
        {
            get
            {
                return tgsSubSessionKey;
            }
            set
            {
                tgsSubSessionKey = value;
            }
        }


        /// <summary>
        /// The ticket returned from TGS request.
        /// </summary>
        internal EncTicketPart TgsTicket
        {
            get
            {
                return tgsTicket;
            }
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Create a KileClientContext instance.
        /// </summary>
        public KileServerContext()
        {
            isInitiator = false;
        }

        #endregion


        /// <summary>
        /// Update the context.
        /// </summary>
        /// <param name="pdu">The Pdu to update the context.</param>
        internal override void UpdateContext(KilePdu pdu)
        {
            if (pdu != null)
            {
                Type pduType = pdu.GetType();

                if (pduType == typeof(KileAsRequest))
                {
                    KileAsRequest request = (KileAsRequest)pdu;

                    if (request.Request != null && request.Request.req_body != null)
                    {
                        cName = request.Request.req_body.cname;
                        cRealm = request.Request.req_body.realm;
                        sName = request.Request.req_body.sname;
                        encryptType = request.Request.req_body.etype;
                        addresses = request.Request.req_body.addresses;
                        nonce = request.Request.req_body.nonce;
                        endTime = request.Request.req_body.till;
                        rtime = request.Request.req_body.rtime;
                    }
                }
                else if (pduType == typeof(KileAsResponse))
                {
                    KileAsResponse response = (KileAsResponse)pdu;
                    tgsSessionKey = response.EncPart.key;
                }
                else if (pduType == typeof(KileTgsRequest))
                {
                    KileTgsRequest request = (KileTgsRequest)pdu;
                    encryptType = request.Request.req_body.etype;
                    nonce = request.Request.req_body.nonce;
                    tgsTicket = request.tgtTicket;
                    sName = request.Request.req_body.sname;

                    if (request.authenticator != null)
                    {
                        tgsSubSessionKey = request.authenticator.subkey;
                    }
                }
                else if (pduType == typeof(KileTgsResponse))
                {
                    KileTgsResponse response = (KileTgsResponse)pdu;
                    apSessionKey = response.EncPart.key;
                }
                else if (pduType == typeof(KileApRequest))
                {
                    KileApRequest request = (KileApRequest)pdu;
                    apRequestCtime = request.Authenticator.ctime;
                    apRequestCusec = request.Authenticator.cusec;

                    if (request.Authenticator.cksum != null)
                    {
                        int flag = BitConverter.ToInt32(request.Authenticator.cksum.checksum.ByteArrayValue,
                            ConstValue.AUTHENTICATOR_CHECKSUM_LENGTH + sizeof(ChecksumFlags));
                        checksumFlag = (ChecksumFlags)flag;
                    }
                    apSubKey = request.Authenticator.subkey;
 
                    if (request.Authenticator.seq_number != null)
                    {
                        currentRemoteSequenceNumber = (ulong)request.Authenticator.seq_number.Value;
                        currentLocalSequenceNumber = currentRemoteSequenceNumber;
                    }
                }
                else if (pduType == typeof(KileApResponse))
                {
                    KileApResponse response = (KileApResponse)pdu;

                    if (response.ApEncPart.subkey != null)
                    {
                        acceptorSubKey = response.ApEncPart.subkey;
                    }
                }
                else
                {
                    // Do nothing.
                }
            }
        }
    }


    /// <summary>
    /// Comparer to determine the rule
    /// </summary>
    class KileServerContextComparer : IEqualityComparer<KileConnection>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(KileConnection x, KileConnection y)
        {
            return (x.TargetEndPoint.Address.Equals(y.TargetEndPoint.Address));
        }


        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The System.Object for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public int GetHashCode(KileConnection obj)
        {
            return obj.TargetEndPoint.Address.ToString().GetHashCode();
        }
    }
}
