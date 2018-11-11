FROM ubuntu:16.04
LABEL \
    com.trilogy.company="Aurea" \
    com.trilogy.maintainer.email="rustem.zinnatullin@versata.com" \
    com.trilogy.maintainer.skype="live:cool_rus_killer"

# Install tools
RUN apt-get -qqy update && apt-get -qqy --force-yes --no-install-recommends install \
  curl \
  ca-certificates \
  openssh-server \
  git \
  sudo

# Install JDK 10
RUN echo "deb http://ppa.launchpad.net/linuxuprising/java/ubuntu bionic main" | tee /etc/apt/sources.list.d/linuxuprising-java.list
RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 73C3DB2A
RUN echo oracle-java10-installer shared/accepted-oracle-license-v1-1 select true | sudo /usr/bin/debconf-set-selections
RUN apt-get -qqy update && apt-get -qqy --force-yes --no-install-recommends install oracle-java10-installer oracle-java10-set-default

# Install NodeJs
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get -qqy update && apt-get -qqy --force-yes --no-install-recommends install nodejs

# Install Google chrome
RUN curl -sL https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add -
RUN echo 'deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main' | tee /etc/apt/sources.list.d/google-chrome.list
RUN apt-get -qqy update && apt-get -qqy --force-yes --no-install-recommends install google-chrome-stable

# Install Allure CLI
RUN curl -s https://s3.amazonaws.com/skyvera-build-repo/Social+Build+Packages/Unix/allure-2.6.0.tgz | tar xvfz - -C /opt
ENV PATH="${PATH}:/opt/allure-2.6.0/bin"

# Add Jenkins user
RUN useradd -ms /bin/bash jenkins -g sudo
RUN echo "jenkins:jenkins" | chpasswd
RUN echo "jenkins ALL=(ALL) NOPASSWD: ALL" >> /etc/sudoers

COPY ./agent-docker-protractor-entrypoint.sh /
RUN chmod +x /agent-docker-protractor-entrypoint.sh

ENTRYPOINT ["/agent-docker-protractor-entrypoint.sh"]