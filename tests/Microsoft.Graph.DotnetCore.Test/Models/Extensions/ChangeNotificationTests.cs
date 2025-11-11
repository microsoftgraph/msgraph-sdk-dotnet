using Microsoft.Graph.Models;
using Xunit;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Microsoft.Graph.DotnetCore.Test.Extensions
{
    public class ChangeNotificationTests
    {
        private readonly X509Certificate2 _certificate;
        public ChangeNotificationTests()
        {
            // This is a DUMMY certificate used to validate the functionality
            var certificateString = "MIIQagIBAzCCEDAGCSqGSIb3DQEHAaCCECEEghAdMIIQGTCCBg8GCSqGSIb3DQEHBqCCBgAwggX8AgEAMIIF9QYJKoZIhvcNAQcBMBwGCiqGSIb3DQEMAQYwDgQIEAk4/VMAFtsCAggAgIIFyAXxkPPBcl1MbwgA3SSTHD3WBxi" +
                                    "qiGVC9+0ufNW70SoIyx7V9ZVP/eFXb/moZD7BEir30WCdqqZCvh3aHvoL1SlreKXFmYqLzUViqBsHl3GIox2f/Ic7CS486JCoLHMoTHPcC3Y40zr8HX+Zc0SJs1cT4KFN3UJnoKwD+lWgn7XOiyzKWC6zksqM2spnc5W6+I5eHo" +
                                    "SDEkgPa6mDYtB+0/9bPSV8XkDu9MWGUhq+bNBlenMwAF+QeWBbaTskiEHgloJPzqVop8aT/KRsKLNBrWQ64JJ5dYG/yjqg0/oA//T8/cCDqhTuc0FiS4IRzmKnTsOuVgbwJ8t3vvd6lHRfFZXTYnMmRLuZ62xvzsAIRCg6+CUmU" +
                                    "fJB9SZodYMD1dC3ScIHoNbbgJUfbUOriC9lL6kLPdxBOAmICMy+47t1PvmFpFJe0fzz8M26Lg5Bbc+pVdwKBDXa2+15Dw/vSiTZuEq1e5C/EJwZDzKU9cskqONGeegxSMDlY12vJR2eY6m/fVrpu58QTAi9kkl5+U4naQp4WXMy" +
                                    "9EydbqNWge1Y3CFxZBldktC6PajhjAF83mMaohAZ+91SfTLx2bar8vxWxCTePSwci2vyZDrzSCvogaNa4CMJViz7Vfbzof4WOTw5tYin9cCNHQuw47hLDVZtIevavAkwruwmXNbd1l7lr9433AdBRh9iiG6uMpwJYAPwj8lkGDU" +
                                    "1H0MFBYjvWMVdh3S4KUkN6kIZPCryFcBKWvqmZn0tVpCbtIlCARXEoz2iYR+VydRW0C5+BlnYCCL60rylirKlRQSm4yzY6vr3wFjWxtEn4SMdR8HUhT7EqAel6AIYO9ZFsJ76GK994l/QMy++pjd4HRIw3SSNoshzQA+y9+MWcP" +
                                    "sUMUj0gS+9NXr/GZ/G4m1gWnuFOnulUWXYD1CctimampvaPwdcWKrUKnzUeMFYxMkMdycEkfePPw4oTYHw5/OgBv4/3PNuuIDBwA0XNop9ixrcNtT+O2eqyITIJLZ6xcxS8aVvrGeGcKs+u0CC4mqvKKVXPLYJ7qN1lznHVEMB7" +
                                    "97JM3SQyhGcYXOqDRV4GlXbAPYbH7P7pbepTF/Y2TascDkcpmX3UeglK6L/zcNG2X+RdjVrJpeNCYVHt9xgQ2eIb9O+6U5eBt25UeUjqa1JBcHf1/XcMIp5+Tf0xO00xV+faI9vXFk5C3DuEOQh6E7Gmp+aPa/s9H/4yV2teuYJ" +
                                    "SxXkszbTvy5bC0C00rD9qFsQORNnZM1MePzbQ0CNAadNiDzdOluDRruwKAGWtxjnjqzMOxfRBZwx2AJfc7EO2zgUaUpoCQQ+Aznnt1zHoWsTP1HcloE3MginzLi76PwwEMbvnc6U2stqsbkENqX6O1OahqeP9C98qlXt12j8vmV" +
                                    "xbFbLRFJYEDkv3hEIOkZmfIUZZ7PtQG6pcz4MXy8VNubgrz1BKd1FDiajGEN9w0z18sszjVRogiTIuST47eN473PmeqMuQDKf4w+nFsQbPYC7Ldxd+DHCdDVXpEeF3ImtmB5cvZnL8VSnCit8Uarws9tj8NCL0RaCJa5aAWGdkb" +
                                    "9+Se4A1sBLn60lODQ0VLGg6M3GQYlLKkGFDNZ13SfBlEzehOE3yIPo+BD2kFoR0Tp1ITMj5CX88EZ30CY1u0vDtjHlFnvCcUcCxA5Ck8QaVR+3ghdUCFyZWjc7pd6ivRnH1AUO3f3HJq+UYbBHvKEG6UYviPGypijsH+4utOdxU" +
                                    "sLCp7Xo06ieotorfbTLMkLcp6G0PykLbT7D+B5f+XNfB5pvjIzB5qo7b9tq4KzVVm67aBCRWF9UQP59/XbHpTL8UCHPB5StAkZNSfaqFIetiJFbYhRK40G5eOiUShX3SZnwxejRb91TrR4in3HuiB8VvAxxzozqJrFBT02XiNuG" +
                                    "3EzW215isLunbU7o3w2ZVrspwWDNJV1kWv0gtg4rls+vt/jSQ+lhwGiZHHVw7WPlnzMwggoCBgkqhkiG9w0BBwGgggnzBIIJ7zCCCeswggnnBgsqhkiG9w0BDAoBAqCCCW4wgglqMBwGCiqGSIb3DQEMAQMwDgQIAE5+HZYwEY8" +
                                    "CAggABIIJSEPsDMNEgZJkFSZUJZ8cuCA1E2e9/jJUu3RPzhoUMRjx++17zprL5LVF4vfQ2Dgd16pQ/IdP2yhK+YHfWvjYvo9E/xPx2V6qXzC7r1VyO0qZSmYuYhVIlMo+vrexuT0UeWQvjXX72DLVcixCGWrUf8qt9CqofChyjn" +
                                    "UddsD9hdoWgNSTgBMi6aNFxlFFfeJMOeTfUbFOGAnUFwySWUnwA3Lx7NrcKWLngmvmyo/zl8++M528SeEGAT7jeZ3NdkI8OqCWlE77ybmZYHXJRgq4D01oVdiQAgnd3Wj8sKmrjIByc23IdIrusHgM5b9BYXdsiEo3seJ6H4V4B" +
                                    "tG5KOPFpM3m2KwZDtlLfgj4Od/XbyZwtRkLOVvOA8ARtDPlfIR8nW+ptFpMlaWGX72oreMm6utQ3OWJtjx+xFKm+VgVhJpJrt1NC1U1vnVp3apwcSXB66nf6gxfipQoUubUoFqUbIBA6lVECVN2XQcO9oHF4exOxAXA0/R45dMm" +
                                    "UIRAc81x6B5I/sRWxYybwtWDUvilLdpjmgzjrQZM8S7EiG13r8mRbYXgtAHFxDv80DYZuywutclEYrFEVoXLGmXBXqlw/uFRQq9ee9xFbrYet8nYCIsUhPc5xF3bLG5bNaIhNrey3+53PlX6ralAfDmCFUHFor2pVnMP0HxG7bq" +
                                    "8ylUNzIVbcliDFIeukdF0fBc0L7VtGaXKLKSZPx7QE4W3dzGRkBPTuG13wOf7batwdV5AwBUoNXLKqbvzqj/M6LgCTdtZ0Qlf7MKH1Av2aYxIV9m/053CKL3tmCj06EkuTWhmMQcfckrnMoInVrmgOpsjX0nQ1EaxkglJtpm2u0" +
                                    "MKN7f9liXOzg5x1aUvIIEddJUxTnpbcl8AEGnPuZvScsQ9JajbRA8v+0gv+qLIgh4esC+AV4ufRV01HOjA/30S1WTAykU+HPvLq/goz8SwtLVmD9F1n5ppWULLYbQObKVUmGiJWjvFDdVtuR4XA1SpBO6nC4wL/Qe2CG360uj9s" +
                                    "zvgDXYVF108/Xr/pJqwHhyb3dujsPre73zS2AWjKPRC/qbe+LZw+Yj4KVD3MslFg14CkS/TPK1zdUyBEnNJIBatbp28/NNX3bMd2TaB7mIlr4T2iSQI4yf5U5gxnPXGOUeqLqKbi7iUbHHk6407PkyIZPyBxUaSIi/KtpUkGvY+" +
                                    "aTAtLLA5F6tKp6FpsvbGBUkOCBcAMLc36Se9GG6UfBf6ZIFtZBpugp4+aZlKxzzigEF+8S4v4/4lm4HcLE7dC8ChD+fPtAQqqMjWmJnrp1Jm20URW//8mk7WVzNTEPuRIeFXTLw52pRtO6E51V085lX3cvEvNgcN3GiCnztb5W7" +
                                    "Tx5eYFGbkXKhmc8OSbNZ1QfAlWwPyVumFujC7bLiCp6V9R0MMUlGY6BiJwFNGM0Isoz7v3Y2DLlYdztdNto9I1+73mMXsCnsCmQTE4pqjGX4imva64pIELuQ2AE2ecAZ7/J/v3DXhsgUXkAnjZIvqnAr/UOBkDDjLc7xByGEkzD" +
                                    "D0PFQclF4ehxo8s8ttUT9VXmLuWgj1inbIU7gcTWaVZFA+4cTeuKDfOCQ+LNaYrv3EZ96FuEO/Dj0Eo+7iiIvWm13ggN+39Bmbp+nerB2r0geAOO6QiPIRD8v2Slwv2Pv3CrBhSX9mVAFt195ZFd3sojhGgqlcJ4tRdV/pGb5At" +
                                    "4T4D0qcRop3aOQ9UST5e1Gmc2w3+z07tCEBsp+teQurAVjX7laEHhA2oavJii9DGAau94X63lURBEQmX8EE6b/9k432dTw5evCkzzO3XMyssvXuEHeuSPnFnLkHFrn9IuHh9LkZvTkQbXRuVVhjnmrfy8Hgq9hK/Tgfax0vow8G" +
                                    "v3CVPptYxL6uo+N4aHHROU4IkOiaV8hUIRFeKh6uE8ILDxWKo+QT5i1iwsm6mhm4cZno7NxCseIXmveU47qhJ/FuwMRVzUfvIzeanEoNUUEEyurqgDSJWqtZLHa9N2FbHHbR30YF7HekH48mvB7MXcHywHEcgMo8rL4I1F820Bd" +
                                    "tLL4xXc1g0NoFWpnrBavoi6mCNcqc4eULIcF5MPg9k1xE663Sw6xlrVKEgXDHHivsv4Y0D5EYRxcqeOkkQ4AwH0a7Y7ps2ZsUxVenXtBqSeaGgY5tY4GX55+ko9tyyOkVV9XT6JcBfCxPtwEeyV+oVlMRg9alVCiw7scMeFFDiH" +
                                    "+4a6CI/J0hyluBjuChypu6i1UjJDC+GloiyiiRktBw1b7Hytg5w8u9tTMNCVNHWLuvGSmzPyYymAIiRSqrCtVH/APv+SWtGC+eNh5+mZc0hz7hHi6gmc7zB/58+VVOdm0vqGaQx28uv5Pht5yw7KgKgtFt//0KvAsCKYso6FsTU" +
                                    "4IzJL3uBPp20xb5Vka4I69c3ysd8Jcx2Y3fykech34fhRLIqJRBo42+ekhAEkF5nZTVFBYgOFv6jir4gTxI4Bax6ukBNDQYDY9VL+dIDU1/PPtepHRNB6lqlKX4Y5T6tqn8u5UbeMVug+ket0oaQ4SObAOkrJdgyE1aGXfSYGoD" +
                                    "vOYz8OCFWNJjDECCrZgniKbV+fxgcOExbXD1Au9W0wgHnagT+uoik0rshi6nsIel4XmVv/MiQowK35s6Olq4mrdRPoOwoePuo3/CEL+BwRlX0aJhFgRS5O0L/zD8Hc8EPR6CO9+8jbkbBQ80KnVsS25ArgoA45CSFCrmqRxFnnp" +
                                    "R6Dvlr0EmlDfGOnFlnZXZNIuPYZZT6UbH0ObaxDKYMPZ2NRbfETfdDHM+WBPuqGVc6OiMqa7PFkHjispf7saXtSrcpL+UYvNzX4PQwpUi8frl0Aq7w7c8GKosmaNp3VYiTc9cAcd/JlX5dAZK2yndVpmQlUeA028j5Lyc9Hm9Gn" +
                                    "T6wjPT4x2lYvXd+AwOBY/3CY2eAslCN+4nmoRZnovDH4Ffp2bnId9FrsViBDWLKWV63yN2OTnTPJxj7ZQEC6T78sdqEpw5vKdi3xYYj2MhBXNohE0lK3Ig4ijsB9P16bXA8PcKaIwhnpeTKsLcdBPwVapuDku24u4u/Z/A+Q3Ls" +
                                    "lbEJdiRhGrHv6I+MJd2Gx/1qBU6VO4N/vC/VL3uv5VY/zRcA4r4ff7m7nfsuwyz5JsLMIcQEx0LuKyy74XmayhpdDE1RlovO0+JkzFmMCMGCSqGSIb3DQEJFTEWBBRLlTU+CGrTcZZgas+DShRTLwPm2zA/BgkqhkiG9w0BCRQx" +
                                    "Mh4wAHIAaQBjAGgAbgBvAHQAaQBmAGkAYwBhAHQAaQBvAG4AcwBhAHAAcAAuAGMAbwBtMDEwITAJBgUrDgMCGgUABBShhhfLZmAOmqGltImT+9krDrQGAgQId7jD11L05jECAggA";
            var secureString = new SecureString();
            secureString.AppendChar('r');
            secureString.AppendChar('i');
            secureString.AppendChar('c');
            secureString.AppendChar('h');
            this._certificate = new X509Certificate2(Convert.FromBase64String(certificateString), secureString);

            // register the default serialization instance as the generator would.
            ParseNodeFactoryRegistry.DefaultInstance.ContentTypeAssociatedFactories.TryAdd(CoreConstants.MimeTypeNames.Application.Json, new JsonParseNodeFactory());
        }


        [Fact]
        public void AddPublicEncryptionCertificate()
        {
            // arrange
            var subscription = new Subscription();

            // act
            subscription.AddPublicEncryptionCertificate(_certificate);

            // assert
            Assert.NotNull(subscription.EncryptionCertificate);

            // Assert that the cert only has the public key
            var addedCertificate = new X509Certificate2(Convert.FromBase64String(subscription.EncryptionCertificate));
            Assert.False(addedCertificate.HasPrivateKey);
        }

        [Fact]
        public async Task DecryptableContentCanBeDecryptedWithCertificate()
        {
            // Arrange
            var testChangeNotificationEncryptedContent = new ChangeNotificationEncryptedContent
            {
                Data = "FFYlP1Bgb/fWW2kHMZiq4Y98E+XL0QTWEnGogTF6RRS+i3KqlXw35yy5ax8fEOzJbLc10ky24Ij+5ei2Hwqkzhph35XdLIsVsJZlQNYBwOu4jKvYbbhc1uHpQ/QBbs" +
                       "4IcdtWKCojqnDYcJmhwkzOZYHUr6XFHHD0GbO3y/wE0BKxMG6d5gNMfbT08OSWl+bhETeGVif8GTgZ0CNA6j7Xlq2T9Jd512cEBtEbXgJoISJVyOo4YzSirrb4R9xr" +
                       "lw9ASdz+oEzKZeUh0NSKfihjvevg90f7r5ZCHH1bP13Fxi/9NxASS7Sv28kvQbl+bqjNvCXK/Ol7rQr4DfMXPG82BGYU8n5AmWBztTY4mZLR59896coFz4CCDai4aS" +
                       "WDO1ldldvW9eqsnWTukQSwef3nHMMwTNxGge5YRMFKfVjOKr55xI7bevi2pZ6iZm8Kp8F+Gi+5V1uDpUFqeeFG3z03e7TfqczNIHdIjqxFpdYlrh/7ySd3L3q4D3TT" +
                       "vVCRdrbjuJ4oZeuFG4PQbAmJBcMwLrWDBmAykTRtrMT1Y1Ur1lX6lTiikGkrlV1VPizykLZmkq6jeoJOnMVLDWpNlQSKKfDicHRWoBHxDHc/g0aPs1g9Jd0I06YsVi" +
                       "JsEhvRz5Kwp4jAbyDff1XVExYPKRA07EfbOl5dLReE6ATcJGBr1dI4VVECRS7yW+uYTxoUUyePUOGIPGgpCBzJGYoRXKpBibcRib4Xs6WHVrEwNkN2RTHneh7NdzUm" +
                       "Piv5RoTSBFKRgysb5pWt1aUwIOnvjxLPIvTJmOob6nYvR/qCkfczEDzofYjG8H/7m2n/tqVvrs73QH7bIgapSU6GMhg41+Sizkjo4NRaIg2xrn7KM9NRJpjhsw5IyP" +
                       "Df2VgJlO9CruoCOHnbSlXCMeQUXATmXc7+bp4Zg18D2IXDryHhmc5GaBgrhzKjZtfvFzkLjY57VXODrsUB5Erya39RaX5bkqDXgzxHR3LWXZPlfuXCPKG5sPc1fGcP" +
                       "nS3+xONICej5xGxzdEo/t9esmGPWCSv3EyxBY+r7PIsNQ2gzwE5WERiRE83NHXrM1sYoSg83NqL5yZ/ohhR8lU3MTJ4xypnAglh+UdYIwqKaO4LKXaSO1Wg2MXWFAH" +
                       "BNVAYY64OrxUwm4kUS5T8CPypGKm5qHWJsWZ2dryGTwEoAKfVM5kWfhQ+56jpwN0AxCtgvGBvt7FX0S5UFa9rMf3EYgsXDQLw+o6N6W9LRC+nmQX+HTyl1mgHf/aGx" +
                       "8EW3DH3Ho52WgBf5IJ/TsvhLpDF6SKZrKLa1qm9PzShR0CGkLl+39pOT9bvcYhVW9I/mI6qv/84ben4NC0nDV31DdGTlB/pY7pIpmQuqSUQi+QAOQqO6oAYP5hh8Ey" +
                       "SQWapIyGdLE3R5HXEQJNVRYZM3BFlQ68HdPOi45KOp3PUAll3GNyxvjzE4UfeSTNGLMEll4Q2V3DlP1JcfIQNBi2SrVPtdq2A7l5NjyPoLnxKF8aoDWfunp0dAJcl" +
                       "eZNecO1YSXliGeisSiuumCTBKoLlx18XUZ4lfimtFChOnqC80RoVGSMTkM4anng99IHLUp/cOwRvnPmThGeTJX294ZsGlxrjmS3p/6DACHZKzy15GHYwhioMUDmcmX" +
                       "VYC2EkN/QPFd/nGUi6KM/dMpJ3mqXxyqP+F4d4b+Dv64QBijF5OFUffc9c46r5aoh0enIdY3TmC/hFloCQlHcrU83LBO2880TKnJI5xPbjjtZZxjA==",
                DataKey = "PfUrKAM9G3k7Bx3XUAQ7jJwvceKrJwO7immbL6c+cFU2RCRicRAAA35C5c2iuEItNxQoXEHBei9aalToPg6XaOVqU7Y2U0vYZ/OPJ9+7gXRk4zYdLTWQgZMeXaa" +
                          "NgJIE0xc8BCuYKacT/iB6aY9JHmj2rbR6EDbMTKWkVBe+Z/qtQFhJFq9WBLXsh719qLl/MQarYCDrTNQtryF0WXn0UuLh2OIJYV9T8eSv4j1ZM0WDKw0X9MLaqF" +
                          "PZsZ0SXX4t2EArdnrCBf5duPPCcmfhnvrimqiynSJPDQT0e63oLlpW1z37TvZTeyORY1YTQRmaKWD91fiYtuVmSSVVy2vg+Fm7UIG082bc8y7LT241Qd5RosJaf" +
                          "1w+JPZbttjm7I6uT22XOzaNRouQWx5UxRvWllm46F3pFNq0dn0lztdsW0QckAV4M86wwObVZbqUbnDZ8YloHz0XRRg7cU0H1K60fPMAo7PUoMV+bJC9HzB5O8jp" +
                          "TScDd4yOYZPB1liV2PHRHuIB23lVUARe3MuMo4i+hAc/ftK9s7yvREBuBSD0wi9R6qCygZ09YwrqfXZjRlKcFnz6EE7sqT1tzs4OxdT8XgAdveV6PU968kQhema" +
                          "TsSSrmpvsVn46mMb1le2YY5PUukxZoUFiDMZb036C56HAQ2cyWZkNweDxDQXdHOvvfmU=",
                DataSignature = "wAtDAqtryLgLo4zhy8BOpqTjf6BYlGv1I9acDpKQo5w=",
                EncryptionCertificateId = "custom-id-for-testing",
                EncryptionCertificateThumbprint = "4B95353E086AD37196606ACF834A14532F03E6DB"
            };

            // Act
            var chatMessage = await testChangeNotificationEncryptedContent.DecryptAsync<ChatMessage>((_, thumbprint) => Task.FromResult(this._certificate));

            // Assert that decryption is okay
            Assert.Equal("1625126194597", chatMessage.Etag);
            Assert.Equal("Hello World", chatMessage.Body.Content);
            Assert.Equal(BodyType.Text, chatMessage.Body.ContentType);
        }
    }
}
