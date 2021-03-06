﻿// Copyright 2017 Matt Howlett, https://www.matthowlett.com
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Refer to LICENSE for more information.

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;


namespace NKafka
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            var headers = new Headers();
            headers.AddHeader("my-test-header", "sdf");

            var c = new ProducerConfig
            { 
                BootstrapServers = "localhost:9092",
                ClientId = "test-client",
                RequiredAcks = Acks.One,
                MaxMessageSize = 1024,
                RequestTimeoutMilliseconds = 10000
            };

            using (var p = new Producer(c))
            {
                var r = p.Produce("test-topic-1", null, Encoding.UTF8.GetBytes("AAAABBBBCCCC"));
                p.Flush(TimeSpan.FromSeconds(10));
            }
        }
    }
}
