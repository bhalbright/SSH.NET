using System;
using Renci.SshNet.Common;
using Renci.SshNet.Security.Cryptography;

namespace Renci.SshNet.Security
{
    /// <summary>
    /// Representation of an EdDsa key. This implementation assumes ussage of the ED25519 signature
    /// scheme, which is the most common. 
    /// </summary>
    public class EdDSAKey : Key, IDisposable
    {
        private Ed25519DigitalSignature _digitalSignature;

        //TODO should I really assume ED25519 or make the caller pass a "signature scheme" enum
        //indicating the one desired (only ED25519 would be supported).

        //TODO this is half baked, not really working yet.

        /// <summary>
        /// Creates a new EdDsaKey instance.
        /// </summary>
        public EdDSAKey()
        {
        }

        /// <summary>
        /// Creates a new EdDsaKey instance.
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        public EdDSAKey(byte[] publicKey, byte[] privateKey)
        {
            _privateKey = new BigInteger[] { new BigInteger(privateKey) };
            _publicKey = new BigInteger[] { new BigInteger(publicKey) };
        }

        /// <summary>
        /// Gets the digital signature.
        /// </summary>
        protected override DigitalSignature DigitalSignature
        {
            get
            {
                if (_digitalSignature == null)
                {
                    _digitalSignature = new Ed25519DigitalSignature(this);
                }
                return _digitalSignature;
            }
        }

        private BigInteger[] _publicKey;
        /// <summary>
        /// 
        /// </summary>
        public override BigInteger[] Public
        {
            get
            {
                return _publicKey;
            }
            set
            {
                _publicKey = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override int KeyLength
        {
            //TODO implement me
            get
            {
                return 0;
            }
        }

        #region IDisposable Members

        private bool _isDisposed;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                //TODO
                /*
                var digitalSignature = _digitalSignature;
                if (digitalSignature != null)
                {
                    digitalSignature.Dispose();
                    _digitalSignature = null;
                }
                */
                _isDisposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="EdDSAKey"/> is reclaimed by garbage collection.
        /// </summary>
        ~EdDSAKey()
        {
            Dispose(false);
        }

        #endregion
    }
}
