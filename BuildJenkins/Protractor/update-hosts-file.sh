#!/bin/bash

ETC_HOSTS=/etc/hosts
HOSTS_LINE="$1\t$2"

# Removing existing entry
sudo sed -i "/$2/d" $ETC_HOSTS

# Adding updated entry
sudo sh -c -e "echo '$HOSTS_LINE' >> $ETC_HOSTS"