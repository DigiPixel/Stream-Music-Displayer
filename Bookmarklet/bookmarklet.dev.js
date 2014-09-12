(function(a,b,c){function d(a){return"[object Function]"==o.call(a)}function e(a){return"string"==typeof a}function f(){}function g(a){return!a||"loaded"==a||"complete"==a||"uninitialized"==a}function h(){var a=p.shift();q=1,a?a.t?m(function(){("c"==a.t?B.injectCss:B.injectJs)(a.s,0,a.a,a.x,a.e,1)},0):(a(),h()):q=0}function i(a,c,d,e,f,i,j){function k(b){if(!o&&g(l.readyState)&&(u.r=o=1,!q&&h(),l.onload=l.onreadystatechange=null,b)){"img"!=a&&m(function(){t.removeChild(l)},50);for(var d in y[c])y[c].hasOwnProperty(d)&&y[c][d].onload()}}var j=j||B.errorTimeout,l=b.createElement(a),o=0,r=0,u={t:d,s:c,e:f,a:i,x:j};1===y[c]&&(r=1,y[c]=[]),"object"==a?l.data=c:(l.src=c,l.type=a),l.width=l.height="0",l.onerror=l.onload=l.onreadystatechange=function(){k.call(this,r)},p.splice(e,0,u),"img"!=a&&(r||2===y[c]?(t.insertBefore(l,s?null:n),m(k,j)):y[c].push(l))}function j(a,b,c,d,f){return q=0,b=b||"j",e(a)?i("c"==b?v:u,a,b,this.i++,c,d,f):(p.splice(this.i++,0,a),1==p.length&&h()),this}function k(){var a=B;return a.loader={load:j,i:0},a}var l=b.documentElement,m=a.setTimeout,n=b.getElementsByTagName("script")[0],o={}.toString,p=[],q=0,r="MozAppearance"in l.style,s=r&&!!b.createRange().compareNode,t=s?l:n.parentNode,l=a.opera&&"[object Opera]"==o.call(a.opera),l=!!b.attachEvent&&!l,u=r?"object":l?"script":"img",v=l?"script":u,w=Array.isArray||function(a){return"[object Array]"==o.call(a)},x=[],y={},z={timeout:function(a,b){return b.length&&(a.timeout=b[0]),a}},A,B;B=function(a){function b(a){var a=a.split("!"),b=x.length,c=a.pop(),d=a.length,c={url:c,origUrl:c,prefixes:a},e,f,g;for(f=0;f<d;f++)g=a[f].split("="),(e=z[g.shift()])&&(c=e(c,g));for(f=0;f<b;f++)c=x[f](c);return c}function g(a,e,f,g,h){var i=b(a),j=i.autoCallback;i.url.split(".").pop().split("?").shift(),i.bypass||(e&&(e=d(e)?e:e[a]||e[g]||e[a.split("/").pop().split("?")[0]]),i.instead?i.instead(a,e,f,g,h):(y[i.url]?i.noexec=!0:y[i.url]=1,f.load(i.url,i.forceCSS||!i.forceJS&&"css"==i.url.split(".").pop().split("?").shift()?"c":c,i.noexec,i.attrs,i.timeout),(d(e)||d(j))&&f.load(function(){k(),e&&e(i.origUrl,h,g),j&&j(i.origUrl,h,g),y[i.url]=2})))}function h(a,b){function c(a,c){if(a){if(e(a))c||(j=function(){var a=[].slice.call(arguments);k.apply(this,a),l()}),g(a,j,b,0,h);else if(Object(a)===a)for(n in m=function(){var b=0,c;for(c in a)a.hasOwnProperty(c)&&b++;return b}(),a)a.hasOwnProperty(n)&&(!c&&!--m&&(d(j)?j=function(){var a=[].slice.call(arguments);k.apply(this,a),l()}:j[n]=function(a){return function(){var b=[].slice.call(arguments);a&&a.apply(this,b),l()}}(k[n])),g(a[n],j,b,n,h))}else!c&&l()}var h=!!a.test,i=a.load||a.both,j=a.callback||f,k=j,l=a.complete||f,m,n;c(h?a.yep:a.nope,!!i),i&&c(i)}var i,j,l=this.yepnope.loader;if(e(a))g(a,0,l,0);else if(w(a))for(i=0;i<a.length;i++)j=a[i],e(j)?g(j,0,l,0):w(j)?B(j):Object(j)===j&&h(j,l);else Object(a)===a&&h(a,l)},B.addPrefix=function(a,b){z[a]=b},B.addFilter=function(a){x.push(a)},B.errorTimeout=1e4,null==b.readyState&&b.addEventListener&&(b.readyState="loading",b.addEventListener("DOMContentLoaded",A=function(){b.removeEventListener("DOMContentLoaded",A,0),b.readyState="complete"},0)),a.yepnope=k(),a.yepnope.executeStack=h,a.yepnope.injectJs=function(a,c,d,e,i,j){var k=b.createElement("script"),l,o,e=e||B.errorTimeout;k.src=a;for(o in d)k.setAttribute(o,d[o]);c=j?h:c||f,k.onreadystatechange=k.onload=function(){!l&&g(k.readyState)&&(l=1,c(),k.onload=k.onreadystatechange=null)},m(function(){l||(l=1,c(1))},e),i?k.onload():n.parentNode.insertBefore(k,n)},a.yepnope.injectCss=function(a,c,d,e,g,i){var e=b.createElement("link"),j,c=i?h:c||f;e.href=a,e.rel="stylesheet",e.type="text/css";for(j in d)e.setAttribute(j,d[j]);g||(n.parentNode.insertBefore(e,n),m(c,0))}})(this,document);

(function () {
  "use strict";
  var interval,
      site,
      site_supported = false,
      identifier,
      
	  nightbot = function () {
        var song = $("#currentTitle").text(),
            title = "Nightbot - " + song;
        return {
            song: song,
            title: title
        };
      },
	  
      grooveshark = function () {
        var song = $("#now-playing-metadata").text(),
            title = "Grooveshark - " + song;
        return {
            song: song,
            title: title
        };
      },
      
      pandora = function () {
        var song = $(".info .playerBarSong").text() + " - " + $(".info .playerBarArtist").text(),
            title = "Pandora - " + song;
        return {
            song: song,
            title: title
        };
      },
      
      plug = function () {
        var song = $("#now-playing-bar .bar-value").text(),
            title = "Plug.dj - " + song;
        return {
            song: song,
            title: title
        };
      },
      
      zaycev = function () {
        var song = $("#zp_current_song .ontheair_artist").text() + $("#zp_current_song .ontheair_song").text(),
            title = "Zaycev - " + song;
        return {
            song: song,
            title: title
        };
      }, 
      
      eighttracks = function () {
        var song = $("#now_playing .title_artist .t").text() + " - " + $("#now_playing .title_artist .a").text(),
            title = "8tracks - " + song;
        if ($("#now_playing .title_artist .t").text() === "") {
          return false;
        }
        return {
            song: song,
            title: title
        };
      },

      googleplay = function () {
        var song = $("#playerSongTitle").text() + " - " + $("#playerSongTitle").next().text().split("-")[0],
            title = song + " - My Library - Google Play";
        if (song.length < 4) { // " - " is of length 3
          return false;
        }
        return {
          song: song,
          title: title
        };
      },
      
      rdio = function () {
        var song = $(".song_title").text() + " - " + $(".text_metadata .artist_title").text(),
            title = "Rdio - " + song;
        return {
            song: song,
            title: title
        };
      },
      
      soundcloud = function () {
        var song = $("a.playbackTitle__link").text(),
            title = "Soundcloud - " + song;
        return {
            song: song,
            title: title
        };
      },
      
      youtify = function () {
        var song = $(".info .title").text(),
            title = "Youtify - " + song;
        return {
            song: song,
            title: title
        };
      },

      musicunlimited = function () {
        var song = $(".GEKKVSQBL- a")[0].text + " - " + $(".GEKKVSQBL- a")[1].text + " - " + $(".GEKKVSQBL- a")[2].text,
            title = "Music Unlimited - " + song;

        return {
          song: song,
          title: title
        };
      },
      
      redirects = {
		"nightbot": nightbot,
        "grooveshark": grooveshark,
        "plug": plug,
        "pandora": pandora,
        "zaycev": zaycev,
        "8tracks": eighttracks,
        "rdio": rdio,
        "soundcloud": soundcloud,
        "youtify": youtify,
        "play.google": googleplay,
        "music.sonyentertainmentnetwork": musicunlimited
      },
      
      check_song = function () {
        var song = identifier();
        set_song(song);
      },

      set_song = function (song) {
        if (song) {
          $('title').text(song.title);
          $('.smd-nowplaying').text(song.song);
        } else {
		  $('title').text('No Song Avalible');
          $('.smd-nowplaying').text("No song playing");
        }
      },
      
      start = function () {
        if (site_supported) {
          check_song();
          interval = setInterval(check_song, 1000);
        }
      },
      
      stop = function () {
        if (interval) {
          clearInterval(interval);
          set_song();
        }
      },
      
      website_name = function () {
        var e = window.location.host;
        return e;
      },
      
      not_supported = function () {
        console.log("Not supported.");
        site_supported = false;
        $('.smd-supported').addClass('unsupported');
		$('.smd-supported').html( "Your on: <span>" + website_name() + ", which not <a href='https://obsproject.com/forum/resources/stream-music-displayer.107/' target='_blank' >supported</a>.</span>" );
      },
      
      supported = function () {
        console.log("Supported! :)");
        site_supported = true;
        $('.smd-supported').addClass('supported');
		$('.smd-supported').html( "Your on: <span>" + website_name() + ", which is <a href='https://obsproject.com/forum/resources/stream-music-displayer.107/' target='_blank' >supported</a>.</span>" );
      },
      
      check_for_support = function () {
        var website = website_name(), redirect;
        for (redirect in redirects) {
          if (website.indexOf(redirect) !== -1) {
            identifier = redirects[redirect];
            supported();
          }
        }
        if (!site_supported) {
          not_supported();
        }
        console.log("check_support: " + site_supported);
      },
      
      add_to_document = function (testResult, key) {
        $ = window.jQuery;
        var html = "<style>*{margin: 0;padding: 0;}</style><div class='smd-container'><style>.smd-container *{margin: 0;padding: 0;}.smd-container a{cursor: pointer;color: #f77f00;text-decoration: none;}.smd-container{background-color: #1C1C1E;box-shadow: 0 0 3px black;border: 1px solid #000;color: #fff;-webkit-border-radius: 5px;-moz-border-radius: 5px;border-radius: 5px;position: fixed;z-index:50000;bottom: 30px;right: 30px;width: 400px;height: 130px;font-family:arial;}.smd-container .button{-moz-box-shadow:inset 0px 1px 0px 0px #54a3f7;-webkit-box-shadow:inset 0px 1px 0px 0px #54a3f7;box-shadow:inset 0px 1px 0px 0px #54a3f7;background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #007dc1), color-stop(1, #0061a7));background:-moz-linear-gradient(top, #007dc1 5%, #0061a7 100%);background:-webkit-linear-gradient(top, #007dc1 5%, #0061a7 100%);background:-o-linear-gradient(top, #007dc1 5%, #0061a7 100%);background:-ms-linear-gradient(top, #007dc1 5%, #0061a7 100%);background:linear-gradient(to bottom, #007dc1 5%, #0061a7 100%);filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#007dc1', endColorstr='#0061a7',GradientType=0);background-color:#007dc1;-moz-border-radius:3px;-webkit-border-radius:3px;border-radius:3px;border:1px solid #124d77;display:inline-block;cursor:pointer;color:#ffffff;font-family:arial;font-size:13px;padding:6px 24px;text-decoration:none;text-shadow:0px 1px 0px #154682;}.smd-container .button:hover{background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #0061a7), color-stop(1, #007dc1));background:-moz-linear-gradient(top, #0061a7 5%, #007dc1 100%);background:-webkit-linear-gradient(top, #0061a7 5%, #007dc1 100%);background:-o-linear-gradient(top, #0061a7 5%, #007dc1 100%);background:-ms-linear-gradient(top, #0061a7 5%, #007dc1 100%);background:linear-gradient(to bottom, #0061a7 5%, #007dc1 100%);filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#0061a7', endColorstr='#007dc1',GradientType=0);background-color:#0061a7;}.smd-container .button:active{position:relative;top:1px;}.smd-container .button.active{-moz-box-shadow:inset 0px 1px 0px 0px #a4e271;-webkit-box-shadow:inset 0px 1px 0px 0px #a4e271;box-shadow:inset 0px 1px 0px 0px #a4e271;background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #89c403), color-stop(1, #77a809));background:-moz-linear-gradient(top, #89c403 5%, #77a809 100%);background:-webkit-linear-gradient(top, #89c403 5%, #77a809 100%);background:-o-linear-gradient(top, #89c403 5%, #77a809 100%);background:-ms-linear-gradient(top, #89c403 5%, #77a809 100%);background:linear-gradient(to bottom, #89c403 5%, #77a809 100%);filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#89c403', endColorstr='#77a809',GradientType=0);background-color:#89c403;-moz-border-radius:3px;-webkit-border-radius:3px;border-radius:3px;border:1px solid #74b807;display:inline-block;cursor:pointer;color:#ffffff;font-family:arial;font-size:13px;padding:6px 24px;text-decoration:none;text-shadow:0px 1px 0px #528009;}.smd-container .button.active:hover{background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #77a809), color-stop(1, #89c403));background:-moz-linear-gradient(top, #77a809 5%, #89c403 100%);background:-webkit-linear-gradient(top, #77a809 5%, #89c403 100%);background:-o-linear-gradient(top, #77a809 5%, #89c403 100%);background:-ms-linear-gradient(top, #77a809 5%, #89c403 100%);background:linear-gradient(to bottom, #77a809 5%, #89c403 100%);filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#77a809', endColorstr='#89c403',GradientType=0);background-color:#77a809;}.smd-container .button.active:active{position:relative;top:1px;}.smd-container .smd-title{width: 390px;height: 18px;padding: 6px 5px;background: #4e4e50;-webkit-border-top-left-radius: 5px;-webkit-border-top-right-radius: 5px;-moz-border-radius-topleft: 5px;-moz-border-radius-topright: 5px;border-top-left-radius: 5px;border-top-right-radius: 5px;}.smd-container .smd-title .smd-logo{background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNS1jMDIxIDc5LjE1NTc3MiwgMjAxNC8wMS8xMy0xOTo0NDowMCAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTQgKFdpbmRvd3MpIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOkQwNzlCOTI3M0FDMDExRTRCMUNDQ0RDQzE4RTU1RDVCIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOkQwNzlCOTI4M0FDMDExRTRCMUNDQ0RDQzE4RTU1RDVCIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6RDA3OUI5MjUzQUMwMTFFNEIxQ0NDRENDMThFNTVENUIiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6RDA3OUI5MjYzQUMwMTFFNEIxQ0NDRENDMThFNTVENUIiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz7/T4hvAAACvklEQVR42kxTTWsTURS9N28yyWQ6trFtrKYlFLWCutKNC0GqbqQorrpxp7hw6UoQ3evChTtB8QP8AW50ZcEPpIXaKraCiFKrpM2HqWlC0swkM89zH0npg8dk7px77rn33PDk5CTJicfj5tlsNsn3/bEoii5orY8hZOMux2KxV7ZtLzmOY3BhGJqnRTtOp9PZB9ADgM7vBMkB4R3cBZBeZeZPvbiFF0JQwCf6+/tnQSBgUSGEBiSYLu44You4lxF+IrGYgNvtdhZVZ1zXNQlBEJjqAugqo1arZUilGM5jfD8jGEt6TiQS95RSqUajQehVu47D1VqNFtbyOoginvB2kZdIUCsITDYwjOT7ID6qhoeHcxjgI1EilZOJJNeaDZpZWqRDpTKPg2hus0KsFHl2kv3AZ8HiZqB83gLTSZEnyVChO52Q3v/8xpcKoX6mkmi8TXf9FN0M17Q9GqOksqQl7g75tAWWg8IoBwS0+q9AIzVF16IjvNz+Vd8CfJr3p1/wb/5SL+oDbkYIpBVRMm6hsiWJOBq9YaA+ebD+RzhBCU522hD9NzpMOirBy4oZaM8dEChRsCKTxWV5umzTulOm560/NOWfTVua6aVapK+pVcr1ZZkj3nYHuXkL1sztsEyrmKJ03ON3A2/1ytYGW6FNK8nPOjc2wrudtK7WNgVrBgkHZxnLQ1ieN9iDU4ibNlTM4o4OqNIu6SAMeK87SnsGRqgTIYphS//VanWjUqmMKfkPIPjd87wrIGPx2IpbFLfi5LDLKeojkQ37TJsoxuJaoVC4gfcPhgBy/kBOKZPJTGWzWVG03afMpeu7LJDZyHw+/xCt3zZqBSwuQMXHcrk8j9/nQOQMDg4aIgH1lgyyo2KxeB3DuyXfhJx7+y8VhV0sSqVS00NDQxcByqGSqtfr61jz10h8ClxDknvnvwADAHsOrVN+sYlGAAAAAElFTkSuQmCC);background-repeat: no-repeat;background-position: 1px 0px;height: 30px;float: left;padding-left: 25px;}.smd-container .smd-body{width: 390px;padding: 5px;clear:both;}.smd-container .smd-body .smd-supported{width: 400px;font-size: 11px;text-align: center;}.smd-container .smd-body .smd-supported.supported span{color: #76af39;}.smd-container .smd-body .smd-supported.unsupported span{color: #af3939;}.smd-container .smd-body .smd-run{margin: 10px 0px;width: 390px;clear: both;}.smd-container .smd-body .smd-run .smd-nowplaying{float: left;padding: 7px;font-size: 12px;max-width: 256px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis;}.smd-container .smd-body .smd-run .smd-toggle{float: left;margin-left: 10px;}.smd-container .smd-body .smd-info{font-size: 11px;bottom: 0;width: 390px;text-align: right;clear: both;margin-top: 55px;}</style><div class='smd-title'><div class='smd-logo'>Stream Music Displayer!</div></div><div class='smd-body'><div class='smd-supported'></div><div class='smd-run'><button class='button smd-toggle'>Start SMD</button><div class='smd-nowplaying'></div></div><div class='smd-info'>Hide and show me with ctrl-m</div></div></div>";
		$('body').append(html);
        SMDInit();
      },

      inject_libraries = function () {
        if (document.getElementsByClassName("smd-container").length < 1) { // Only add when there are none running
          yepnope({
            test: !!window.jQuery, // Converts the existence of jQuery to a boolean true or false
            nope: "https://cdn.jsdelivr.net/jquery/2.0.3/jquery-2.0.3.min.js",
            complete: add_to_document
          });
          yepnope.injectJs("https://cdn.jsdelivr.net/keymaster.js/1.6.1/keymaster.min.js", function () {
            key("ctrl+m", function () {
              $(".smd-container").fadeToggle(); // Binds the hide me to ctrl-m
            });
          });
        }
      },
      
      SMDInit = function () {
        $('.SMDContainer').hide().fadeIn(200);
      
        check_for_support();
		
        $('.smd-toggle').click(function () {
          if ($(this).text() === "Start SMD") {
			$(this).addClass('active');
            $(this).text("Stop SMD");
            start();
          } else if ($(this).text() === "Stop SMD") {
            $(this).removeClass('active');
            $(this).text("Start SMD");
            stop();
          }
        });
      };
	  
	inject_libraries();
}());