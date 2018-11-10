#!/bin/bash

ETC_HOSTS=/etc/hosts
IP="10.197.1.62" #"%targetAppHost%"
HOSTNAME="sp2013.social.com"
HOSTS_LINE="$IP\t$HOSTNAME"

# Removing existing entry
sudo sed "/$HOSTNAME/d" $ETC_HOSTS

# Adding updated entry
sudo sh -c -e "echo '$HOSTS_LINE' >> $ETC_HOSTS"