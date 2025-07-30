using System;
using UnityEngine;
using UnityEngine.Events;

public class Test_AllColor : MonoBehaviour
{
    public Color[] m_allowsColor = new Color[] { Color.black, Color.red, Color.green, Color.blue };
    public int m_bitCount = 6;
    public int m_maxTextureWidth = 8096;

    public Texture2D m_createdTexture;
    public UnityEvent<Texture2D > m_onChange;

    public bool m_mipChain;
    public bool m_linear;



    public ulong m_maxPossibilityFound;


    public BitLimiteReach m_2bits;
    public BitLimiteReach m_3bits;
    public BitLimiteReach m_4bits;
    public BitLimiteReach m_5bits;
    public BitLimiteReach m_6bits;
    [System.Serializable]
    public class BitLimiteReach {

        public ulong m_maxPossibilityFound;
        public string m_binaryBitsEquivalents;
        public int m_bitsCountEquivalent;
        public int m_byteCountEquivalent;


        public void SetWith2Bits(ulong count, bool bit0, bool bit1, bool bit2, bool bit3, bool bit4, bool bit5)
        {

            if (bit0 && bit1 && !bit2 && !bit3 && !bit4 && !bit5)
                SetWithCount(count);
        }
        public void SetWith3Bits(ulong count, bool bit0, bool bit1, bool bit2, bool bit3, bool bit4, bool bit5)
        {
            if (bit0 && bit1 && bit2 && !bit3 && !bit4 && !bit5)
                SetWithCount(count);

        }
        public void SetWith4Bits(ulong count, bool bit0, bool bit1, bool bit2, bool bit3, bool bit4, bool bit5)
        {

            if (bit0 && bit1 && bit2 && bit3 && !bit4 && !bit5)
                SetWithCount(count);
        }
        public void SetWith5Bits(ulong count, bool bit0, bool bit1, bool bit2, bool bit3, bool bit4, bool bit5)
        {
            if (bit0 && bit1 && bit2 && bit3 && bit4 && !bit5)
                SetWithCount(count);
        }
        public void SetWith6Bits(ulong count, bool bit0, bool bit1, bool bit2, bool bit3, bool bit4, bool bit5)
        {
            if (bit0 && bit1 && bit2 && bit3 && bit4 && bit5)
                SetWithCount(count);

        }

        private void SetWithCount(ulong count)
        {
            m_maxPossibilityFound = count;
            m_binaryBitsEquivalents = Convert.ToString((long)m_maxPossibilityFound, 2);
            m_bitsCountEquivalent = m_binaryBitsEquivalents.Length;
            m_byteCountEquivalent = m_binaryBitsEquivalents.Length / 8;
        }
    }



    [ContextMenu("Refresh")]
    public void Refresh() {

        m_maxPossibilityFound = 0;
        Texture2D t = new Texture2D(m_maxTextureWidth, m_bitCount, TextureFormat.ARGB32,m_mipChain, m_linear);
        t.filterMode = FilterMode.Point;
        t.wrapMode = TextureWrapMode.Clamp;
        int index = 0;
        int colorIndex = 0;
        for (int i = 0; i < int.MaxValue; i++) {

            int bit1Frequence = i % m_allowsColor.Length;
            int bit2Frequence = ((i / m_allowsColor.Length)) % m_allowsColor.Length;
            int bit3Frequence = ((i / (m_allowsColor.Length * m_allowsColor.Length))) % m_allowsColor.Length;
            int bit4Frequence = ((i / (m_allowsColor.Length * m_allowsColor.Length * m_allowsColor.Length))) % m_allowsColor.Length;
            int bit5Frequence = ((i / (m_allowsColor.Length * m_allowsColor.Length * m_allowsColor.Length * m_allowsColor.Length))) % m_allowsColor.Length;
            int bit6Frequence = ((i / (m_allowsColor.Length * m_allowsColor.Length * m_allowsColor.Length * m_allowsColor.Length * m_allowsColor.Length))) % m_allowsColor.Length;
            t.SetPixel(i, 0, m_allowsColor[bit1Frequence]);
            t.SetPixel(i, 1, m_allowsColor[bit2Frequence]);
            t.SetPixel(i, 2, m_allowsColor[bit3Frequence]);
            t.SetPixel(i, 3, m_allowsColor[bit4Frequence]);
            t.SetPixel(i, 4, m_allowsColor[bit5Frequence]);
            t.SetPixel(i, 5, m_allowsColor[bit6Frequence]);



            m_maxPossibilityFound ++;
            bool b0, b1, b2, b3, b4, b5;
            b0 = bit1Frequence == m_allowsColor.Length - 1;
            b1 = bit2Frequence == m_allowsColor.Length - 1;
            b2 = bit3Frequence == m_allowsColor.Length - 1;
            b3 = bit4Frequence == m_allowsColor.Length - 1;
            b4 = bit5Frequence == m_allowsColor.Length - 1;
            b5 = bit6Frequence == m_allowsColor.Length - 1;


            m_2bits.SetWith2Bits(m_maxPossibilityFound, b0, b1, b2, b3, b4, b5);
            m_3bits.SetWith3Bits(m_maxPossibilityFound, b0, b1, b2, b3, b4, b5);
            m_4bits.SetWith4Bits(m_maxPossibilityFound, b0, b1, b2, b3, b4, b5);
            m_5bits.SetWith5Bits(m_maxPossibilityFound, b0, b1, b2, b3, b4, b5);
            m_6bits.SetWith6Bits(m_maxPossibilityFound, b0, b1, b2, b3, b4, b5);

            bool limitReach =
                bit1Frequence == m_allowsColor.Length - 1 &&
                bit2Frequence == m_allowsColor.Length - 1 &&
                bit3Frequence == m_allowsColor.Length - 1 &&
                bit4Frequence == m_allowsColor.Length - 1 &&
                bit5Frequence == m_allowsColor.Length - 1 &&
                bit6Frequence == m_allowsColor.Length - 1 ;
            if (limitReach)
            {
                break;
            }
        }

        m_createdTexture = t;
        m_createdTexture.Apply();
        m_onChange.Invoke(t);
    }

    
}
