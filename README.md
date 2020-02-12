{
    "getReportCrtrV2Response": {
        "return": {
            "fcbStatus": "OK",
            "fcbMessage": "Запрос обработан",
            "result": {
                "responseInfo": {
                    "messageId": "5d0109ba-e4d1-49f0-9158-800319b8749b",
                    "correlationId": "670fa972d6-d534ea5f-2695-4a8b-b05e-d21b8cb78702",
                    "responseDate": "2020-02-11T15:27:18.273+06:00",
                    "status": {
                        "code": "SCSS001",
                        "message": "Message has been processed successfully"
                    },
                    "sessionId": "5f551f50-5a76-4ae2-b7d9-146bb58cb5a6"
                },
                "responseData": {
                    "data": {
                        "responseCode": "PAYMENTS_NOT_FOUND",
                        "requestNumber": "670fa972d6-d534ea5f-2695-4a8b-b05e-d21b8cb78702",
                        "requestIin": "690620401423",
                        "responseDate": "2020-02-11T15:27:18.274+06:00",
                        "responseNumber": "da7b9fb7-5cd1-4356-9495-3dc0b118eceb",
                        "Signature": {
                            "@xmlns": "http://www.w3.org/2000/09/xmldsig#",
                            "SignedInfo": {
                                "CanonicalizationMethod": {
                                    "@Algorithm": "http://www.w3.org/TR/2001/REC-xml-c14n-20010315"
                                },
                                "SignatureMethod": {
                                    "@Algorithm": "http://www.w3.org/2001/04/xmldsig-more#gost34310-gost34311"
                                },
                                "Reference": {
                                    "@URI": "",
                                    "Transforms": {
                                        "Transform": [
                                            {
                                                "@Algorithm": "http://www.w3.org/2000/09/xmldsig#enveloped-signature"
                                            },
                                            {
                                                "@Algorithm": "http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments"
                                            }
                                        ]
                                    },
                                    "DigestMethod": {
                                        "@Algorithm": "http://www.w3.org/2001/04/xmldsig-more#gost34311"
                                    },
                                    "DigestValue": "oSv0xey+EN8eVoBOfjeYS4z6FvK023eyGE7nIATRe9g="
                                }
                            },
                            "SignatureValue": "yVXqbu4m8qWaWM/DqED9CvFO8VQrqfKe10siZ5K39FST1YZLlSG8myKt6mL7MmOJy7gMD6K2w13C+e9mIOrInA==",
                            "KeyInfo": {
                                "X509Data": {
                                    "X509Certificate": "MIIFFDCCBL6gAwIBAgIUXtjAcf99bju00zLKUJVKIQsvbecwDQYJKoMOAwoBAQECBQAwUzELMAkGA1UEBhMCS1oxRDBCBgNVBAMMO9Kw0JvQotCi0KvSmiDQmtCj05jQm9CQ0J3QlNCr0KDQo9Co0Ksg0J7QoNCi0JDQm9Cr0pogKEdPU1QpMB4XDTE5MDIxMjA1MjE0N1oXDTIwMDIxMjA1MjE0N1owggG+MSYwJAYDVQQDDB3QnNCj0JrQo9Co0JXQkiDQndCQ0KDQmNCc0JDQnTEXMBUGA1UEBAwO0JzQo9Ca0KPQqNCV0JIxGDAWBgNVBAUTD0lJTjg0MDUwOTM1MDAzODELMAkGA1UEBhMCS1oxFTATBgNVBAcMDNCQ0KHQotCQ0J3QkDEVMBMGA1UECAwM0JDQodCi0JDQndCQMYHEMIHBBgNVBAoMgbnQk9Ce0KHQo9CU0JDQoNCh0KLQktCV0J3QndCe0JUg0KPQp9Cg0JXQltCU0JXQndCY0JUgItCc0JjQndCY0KHQotCV0KDQodCi0JLQniDQotCg0KPQlNCQINCYINCh0J7QptCY0JDQm9Cs0J3QntCZINCX0JDQqdCY0KLQqyDQndCQ0KHQldCb0JXQndCY0K8g0KDQldCh0J/Qo9CR0JvQmNCa0Jgg0JrQkNCX0JDQpdCh0KLQkNCdIjEYMBYGA1UECwwPQklOMTcwMzQwMDAxMzM5MR0wGwYDVQQqDBTQndCj0KDQm9CQ0J3QntCS0JjQpzEmMCQGCSqGSIb3DQEJARYXTi5NVUtVU0hFVkBFTkJFSy5HT1YuS1owbDAlBgkqgw4DCgEBAQEwGAYKKoMOAwoBAQEBAQYKKoMOAwoBAwEBAANDAARAfxEUFQPxTd4LjTwe7vCZhQnmBFXZa8NfCqc0WyA9+sP0cyFYac7JYkSmxP95EId5nIMstVcOX23VZODfxkcrdqOCAeswggHnMA4GA1UdDwEB/wQEAwIGwDAoBgNVHSUEITAfBggrBgEFBQcDBAYIKoMOAwMEAQIGCSqDDgMDBAECAjAPBgNVHSMECDAGgARbanPpMB0GA1UdDgQWBBR4R7WaxmvnFG2LNYQvFdOrbxJFPTBeBgNVHSAEVzBVMFMGByqDDgMDAgEwSDAhBggrBgEFBQcCARYVaHR0cDovL3BraS5nb3Yua3ovY3BzMCMGCCsGAQUFBwICMBcMFWh0dHA6Ly9wa2kuZ292Lmt6L2NwczBYBgNVHR8EUTBPME2gS6BJhiJodHRwOi8vY3JsLnBraS5nb3Yua3ovbmNhX2dvc3QuY3JshiNodHRwOi8vY3JsMS5wa2kuZ292Lmt6L25jYV9nb3N0LmNybDBcBgNVHS4EVTBTMFGgT6BNhiRodHRwOi8vY3JsLnBraS5nb3Yua3ovbmNhX2RfZ29zdC5jcmyGJWh0dHA6Ly9jcmwxLnBraS5nb3Yua3ovbmNhX2RfZ29zdC5jcmwwYwYIKwYBBQUHAQEEVzBVMC8GCCsGAQUFBzAChiNodHRwOi8vcGtpLmdvdi5rei9jZXJ0L25jYV9nb3N0LmNlcjAiBggrBgEFBQcwAYYWaHR0cDovL29jc3AucGtpLmdvdi5rejANBgkqgw4DCgEBAQIFAANBAAfzIZf6f92XtJH1peKlPd0sHxKWIOb8Lp/R82grC4qnIcz5yle72OR6gZeAYJ9wrXqIyen18B+KO0S6zXc1Wp8="
                                }
                            }
                        }
                    }
                }
            },
            "resultASP": {
                "PersonLargeFamilyResponse": {
                    "iin": "690620401423",
                    "state": "NO"
                }
            },
            "resultESP": {
                "singleAggregatePaymentResponse": {
                    "@xmlns:ns7": "http://www.mtszn.kz/services/PersonCotracts/schemas",
                    "isEspPayer": {
                        "@xmlns": "http://www.mtszn.kz/services/PersonCotracts/schemas",
                        "#text": "false"
                    },
                    "requestGUID": {
                        "@xmlns": "http://www.mtszn.kz/services/PersonCotracts/schemas",
                        "#text": "9dbfa3ae-a7a0-23da-e054-001b782a74a6"
                    },
                    "ds:Signature": {
                        "@xmlns:ds": "http://www.w3.org/2000/09/xmldsig#",
                        "ds:SignedInfo": {
                            "ds:CanonicalizationMethod": {
                                "@Algorithm": "http://www.w3.org/TR/2001/REC-xml-c14n-20010315"
                            },
                            "ds:SignatureMethod": {
                                "@Algorithm": "http://www.w3.org/2001/04/xmldsig-more#gost34310-gost34311"
                            },
                            "ds:Reference": {
                                "@URI": "",
                                "ds:Transforms": {
                                    "ds:Transform": [
                                        {
                                            "@Algorithm": "http://www.w3.org/2000/09/xmldsig#enveloped-signature"
                                        },
                                        {
                                            "@Algorithm": "http://www.w3.org/TR/2001/REC-xml-c14n-20010315#WithComments"
                                        }
                                    ]
                                },
                                "ds:DigestMethod": {
                                    "@Algorithm": "http://www.w3.org/2001/04/xmldsig-more#gost34311"
                                },
                                "ds:DigestValue": "t078zGy/4QYRz5do+OOhDMXDZEuQ1rgwDvm0jVx/PE8="
                            }
                        },
                        "ds:SignatureValue": "\r\nEEYK3n4evsNxHr2wlKuba27jXj0kn8NWjQQMhXSUflaUXGkO5DznvJe+swDViWDqqlbme6wyK4x4\r\nt0o1zA5QYg==\r\n",
                        "ds:KeyInfo": {
                            "ds:X509Data": {
                                "ds:X509Certificate": "\r\nMIIFFDCCBL6gAwIBAgIUXtjAcf99bju00zLKUJVKIQsvbecwDQYJKoMOAwoBAQECBQAwUzELMAkG\r\nA1UEBhMCS1oxRDBCBgNVBAMMO9Kw0JvQotCi0KvSmiDQmtCj05jQm9CQ0J3QlNCr0KDQo9Co0Ksg\r\n0J7QoNCi0JDQm9Cr0pogKEdPU1QpMB4XDTE5MDIxMjA1MjE0N1oXDTIwMDIxMjA1MjE0N1owggG+\r\nMSYwJAYDVQQDDB3QnNCj0JrQo9Co0JXQkiDQndCQ0KDQmNCc0JDQnTEXMBUGA1UEBAwO0JzQo9Ca\r\n0KPQqNCV0JIxGDAWBgNVBAUTD0lJTjg0MDUwOTM1MDAzODELMAkGA1UEBhMCS1oxFTATBgNVBAcM\r\nDNCQ0KHQotCQ0J3QkDEVMBMGA1UECAwM0JDQodCi0JDQndCQMYHEMIHBBgNVBAoMgbnQk9Ce0KHQ\r\no9CU0JDQoNCh0KLQktCV0J3QndCe0JUg0KPQp9Cg0JXQltCU0JXQndCY0JUgItCc0JjQndCY0KHQ\r\notCV0KDQodCi0JLQniDQotCg0KPQlNCQINCYINCh0J7QptCY0JDQm9Cs0J3QntCZINCX0JDQqdCY\r\n0KLQqyDQndCQ0KHQldCb0JXQndCY0K8g0KDQldCh0J/Qo9CR0JvQmNCa0Jgg0JrQkNCX0JDQpdCh\r\n0KLQkNCdIjEYMBYGA1UECwwPQklOMTcwMzQwMDAxMzM5MR0wGwYDVQQqDBTQndCj0KDQm9CQ0J3Q\r\nntCS0JjQpzEmMCQGCSqGSIb3DQEJARYXTi5NVUtVU0hFVkBFTkJFSy5HT1YuS1owbDAlBgkqgw4D\r\nCgEBAQEwGAYKKoMOAwoBAQEBAQYKKoMOAwoBAwEBAANDAARAfxEUFQPxTd4LjTwe7vCZhQnmBFXZ\r\na8NfCqc0WyA9+sP0cyFYac7JYkSmxP95EId5nIMstVcOX23VZODfxkcrdqOCAeswggHnMA4GA1Ud\r\nDwEB/wQEAwIGwDAoBgNVHSUEITAfBggrBgEFBQcDBAYIKoMOAwMEAQIGCSqDDgMDBAECAjAPBgNV\r\nHSMECDAGgARbanPpMB0GA1UdDgQWBBR4R7WaxmvnFG2LNYQvFdOrbxJFPTBeBgNVHSAEVzBVMFMG\r\nByqDDgMDAgEwSDAhBggrBgEFBQcCARYVaHR0cDovL3BraS5nb3Yua3ovY3BzMCMGCCsGAQUFBwIC\r\nMBcMFWh0dHA6Ly9wa2kuZ292Lmt6L2NwczBYBgNVHR8EUTBPME2gS6BJhiJodHRwOi8vY3JsLnBr\r\naS5nb3Yua3ovbmNhX2dvc3QuY3JshiNodHRwOi8vY3JsMS5wa2kuZ292Lmt6L25jYV9nb3N0LmNy\r\nbDBcBgNVHS4EVTBTMFGgT6BNhiRodHRwOi8vY3JsLnBraS5nb3Yua3ovbmNhX2RfZ29zdC5jcmyG\r\nJWh0dHA6Ly9jcmwxLnBraS5nb3Yua3ovbmNhX2RfZ29zdC5jcmwwYwYIKwYBBQUHAQEEVzBVMC8G\r\nCCsGAQUFBzAChiNodHRwOi8vcGtpLmdvdi5rei9jZXJ0L25jYV9nb3N0LmNlcjAiBggrBgEFBQcw\r\nAYYWaHR0cDovL29jc3AucGtpLmdvdi5rejANBgkqgw4DCgEBAQIFAANBAAfzIZf6f92XtJH1peKl\r\nPd0sHxKWIOb8Lp/R82grC4qnIcz5yle72OR6gZeAYJ9wrXqIyen18B+KO0S6zXc1Wp8=\r\n"
                            }
                        }
                    }
                }
            }
        }
    }
}
