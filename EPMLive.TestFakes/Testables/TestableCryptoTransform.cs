using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EPMLive.TestFakes.Testables
{
    public class TestableCryptoTransform : ICryptoTransform
    {
        public bool CanReuseTransform { get; set; }
        public bool CanTransformMultipleBlocks { get; set; }
        public int InputBlockSize { get; set; }
        public int OutputBlockSize { get; set; }

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }

        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            return 0;
        }

        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            return inputBuffer;
        }
    }
}
