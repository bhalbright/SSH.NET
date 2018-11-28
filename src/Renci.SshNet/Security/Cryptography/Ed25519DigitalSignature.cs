using System;
using System.Security.Cryptography;
using Renci.SshNet.Abstractions;
using Renci.SshNet.Common;

namespace Renci.SshNet.Security.Cryptography
{
    /// <summary>
    /// Implements ED25519 digital signature algorithm.
    /// </summary>
    public class Ed25519DigitalSignature : DigitalSignature, IDisposable
    {
        private readonly EdDSAKey _key;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ed25519DigitalSignature" /> class.
        /// </summary>
        /// <param name="key">The EdDSA key.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
        public Ed25519DigitalSignature(EdDSAKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            _key = key;
        }

        /// <summary>
        /// Verifies the signature.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="signature">The signature.</param>
        /// <returns>
        /// <c>true</c> if signature was successfully verified; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="InvalidOperationException">Invalid signature.</exception>
        public override bool Verify(byte[] input, byte[] signature)
        {
            //TODO implement me
            return false;
        }

        /// <summary>
        /// Creates the signature.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// Signed input data.
        /// </returns>
        /// <exception cref="SshException">Invalid DSA key.</exception>
        public override byte[] Sign(byte[] input)
        {
            //TODO implement me
            return null;
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
                _isDisposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Ed25519DigitalSignature"/> is reclaimed by garbage collection.
        /// </summary>
        ~Ed25519DigitalSignature()
        {
            Dispose(false);
        }

        #endregion
    }
}
