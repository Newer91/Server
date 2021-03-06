﻿using BandD.Serwis.Tools.ClientTools;
using BandD.Serwis.Tools.Logger;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace BandD.Serwis.Tools.ServerTools
{
    public static class SecureTools
    {
        public static SecureString convertToSecureString(string strPassword)
        {
            var secureStr = new SecureString();
            try
            {
                if (strPassword.Length > 0)
                {
                    foreach (var c in strPassword.ToCharArray()) secureStr.AppendChar(c);
                }
            }
            catch (Exception e)
            {
                LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
            }
            return secureStr;
        }

        public static string convertToUNSecureString(SecureString secstrPassword)
        {
            string result;
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secstrPassword);
                result= Marshal.PtrToStringUni(unmanagedString);
            }
            catch (Exception e)
            {
                LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                result = "";
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
            return result;
        }

        public static bool SecureStringEqual(SecureString secureString1, SecureString secureString2)
        {
            if (secureString1 == null)
            {
                throw new ArgumentNullException("s1");
            }
            if (secureString2 == null)
            {
                throw new ArgumentNullException("s2");
            }

            if (secureString1.Length != secureString2.Length)
            {
                return false;
            }

            IntPtr ss_bstr1_ptr = IntPtr.Zero;
            IntPtr ss_bstr2_ptr = IntPtr.Zero;

            try
            {
                ss_bstr1_ptr = Marshal.SecureStringToBSTR(secureString1);
                ss_bstr2_ptr = Marshal.SecureStringToBSTR(secureString2);

                String str1 = Marshal.PtrToStringBSTR(ss_bstr1_ptr);
                String str2 = Marshal.PtrToStringBSTR(ss_bstr2_ptr);

                return str1.Equals(str2);
            }
            finally
            {
                if (ss_bstr1_ptr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(ss_bstr1_ptr);
                }

                if (ss_bstr2_ptr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(ss_bstr2_ptr);
                }
            }
        }

        public static string CalculateMD5Hash(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            MD5 md5 = MD5.Create();
            try
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(inputString);
                byte[] hash = md5.ComputeHash(inputBytes);

                for (int i = 0; i < hash.Length; i++)
                    sb.Append(hash[i].ToString("X2"));
            }
            catch (Exception e)
            {
                LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
            }

            return sb.ToString();
        }
    }
}
